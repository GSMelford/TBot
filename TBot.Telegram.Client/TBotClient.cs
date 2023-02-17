using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TBot.Client.Api.Telegram.DeleteMessage;
using TBot.Client.Api.Telegram.EditMessage;
using TBot.Client.Api.Telegram.GetFile;
using TBot.Client.Api.Telegram.GetFileBytes;
using TBot.Client.Api.Telegram.GetUpdates;
using TBot.Client.Api.Telegram.SendMessage;
using TBot.Client.Api.Telegram.SendVideo;
using TBot.Core;
using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Telegram.Dto;
using TBot.Telegram.Dto.Responses;

namespace TBot.Client;

public class TBotClient : ITBot
{
    private readonly ILogger<ITBot>? _logger;
    
    private readonly string _botToken;
    private const string API_URL = "https://api.telegram.org/";
    private string BotTokenPath => $"bot{_botToken}/";

    private readonly Dictionary<string, RequestLimiter> _requestLimiters = new ();

    public TBotClient(string botToken, ILogger<ITBot>? logger = null)
    {
        _botToken = botToken;
        _logger = logger;
    }

    public Task<HttpResponseMessage> SendMessageAsync(SendMessageParameter sendMessageParameter, HttpClient? httpClient = null)
    {
        return DoRequestWithLimiterAsync(
            httpClient,
            new SendMessageBaseRequest(API_URL + BotTokenPath, sendMessageParameter), 
            sendMessageParameter.ChatId.ToString());
    }

    public Task<HttpResponseMessage> SendVideoAsync(SendVideoParameter sendVideoParameter, HttpClient? httpClient = null)
    {
        return DoRequestWithLimiterAsync(
            httpClient, 
            new SendVideoBaseRequest(API_URL + BotTokenPath, sendVideoParameter), 
            sendVideoParameter.ChatId.ToString());
    }

    public Task<HttpResponseMessage> EditMessageAsync(EditMessageParameter editMessageParameter, HttpClient? httpClient = null)
    {
        return DoRequestWithLimiterAsync(
            httpClient, 
            new EditMessageBaseRequest(API_URL + BotTokenPath, editMessageParameter), 
            editMessageParameter.ChatId.ToString());
    }
    
    public Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameter deleteMessageParameter, HttpClient? httpClient = null)
    {
        return DoRequestAsync(httpClient, new DeleteMessageBaseRequest(API_URL + BotTokenPath, deleteMessageParameter));
    }
    
    public Task<HttpResponseMessage> GetFileAsync(GetFileParameter getFileParameter, HttpClient? httpClient = null)
    {
        return DoRequestAsync(httpClient, new GetFileBaseRequest(API_URL + BotTokenPath, getFileParameter));
    }

    public Task<HttpResponseMessage> GetFileBytes(string telegramFilePath, HttpClient? httpClient = null)
    {
        return DoRequestAsync(httpClient, new GetFileBytesBaseRequest($"{API_URL}file/{BotTokenPath}", telegramFilePath));
    }
    
    public async Task<List<Update>> GetUpdates(GetUpdatesParameter getUpdatesParameter, HttpClient? httpClient = null)
    {
        HttpResponseMessage httpResponseMessage =
            await DoRequestAsync(httpClient, new GetUpdatesBaseRequest(API_URL + BotTokenPath, getUpdatesParameter));
        
        return JsonConvert.DeserializeObject<UpdateResponse>(
                   Regex.Unescape(httpResponseMessage.Content.ReadAsStringAsync().Result))?.Result 
               ?? new List<Update>();
    }
    
    private async Task<HttpResponseMessage> DoRequestWithLimiterAsync(HttpClient? httpClient, IRequestSenderService request, string chatId)
    {
        HttpResponseMessage? httpResponseMessage = null;
        AddLimiterIfNotExist(chatId);
        await GetLimiter(chatId).CheckAsync();
        
        try {
            httpResponseMessage = await DoRequestAsync(httpClient, request);
            if (httpResponseMessage is null || !httpResponseMessage.IsSuccessStatusCode) {
                throw new Exception("Status code is not success");
            }
        }
        catch (Exception e) {
            _logger?.LogWarning("Do request. Message: {Message}", e.Message);
        }
        finally {
            GetLimiter(chatId).Complete();
        }
        
        return httpResponseMessage ?? throw new Exception("The bot didn't do a request");
    }

    private void AddLimiterIfNotExist(string chatId)
    {
        if (!_requestLimiters.ContainsKey(chatId))
        {
            _requestLimiters.Add(chatId, new RequestLimiter());
        }
    }
    
    private RequestLimiter GetLimiter(string chatId)
    {
        return _requestLimiters[chatId];
    }
    
    private async Task<HttpResponseMessage> DoRequestAsync(HttpClient? httpClient, IRequestSenderService request)
    {
        return await request.SendAsync(httpClient ?? new HttpClient());
    }
}