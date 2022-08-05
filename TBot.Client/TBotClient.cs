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
using TBot.Core.Interfaces;
using TBot.Telegram.Dto;
using TBot.Telegram.Dto.Responses;

namespace TBot.Client;

public class TBotClient : ITBot
{
    private readonly ILogger<ITBot>? _logger;
    
    private readonly string _botToken;
    private const string API_URL = "https://api.telegram.org/";
    private string BotTokenPath => $"bot{_botToken}/";

    private readonly Dictionary<string, SendRequestLimiter> _requestLimiters = new ();

    public TBotClient(string botToken, ILogger<ITBot>? logger = null)
    {
        _botToken = botToken;
        _logger = logger;
    }

    public Task<HttpResponseMessage> SendMessageAsync(SendMessageParameters sendMessageParameters, HttpClient? httpClient = null)
    {
        return DoRequestWithLimiterAsync(
            httpClient,
            new SendMessageRequest(API_URL + BotTokenPath, sendMessageParameters), 
            sendMessageParameters.ChatId.ToString());
    }

    public Task<HttpResponseMessage> SendVideoAsync(SendVideoParameters sendVideoParameters, HttpClient? httpClient = null)
    {
        return DoRequestWithLimiterAsync(
            httpClient, 
            new SendVideoRequest(API_URL + BotTokenPath, sendVideoParameters), 
            sendVideoParameters.ChatId.ToString());
    }

    public Task<HttpResponseMessage> EditMessageAsync(EditMessageParameters editMessageParameters, HttpClient? httpClient = null)
    {
        return DoRequestWithLimiterAsync(
            httpClient, 
            new EditMessageRequest(API_URL + BotTokenPath, editMessageParameters), 
            editMessageParameters.ChatId.ToString());
    }
    
    public Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters, HttpClient? httpClient = null)
    {
        return DoRequestAsync(httpClient, new DeleteMessageRequest(API_URL + BotTokenPath, deleteMessageParameters));
    }
    
    public Task<HttpResponseMessage> GetFileAsync(GetFileParameters getFileParameters, HttpClient? httpClient = null)
    {
        return DoRequestAsync(httpClient, new GetFileRequest(API_URL + BotTokenPath, getFileParameters));
    }

    public Task<HttpResponseMessage> GetFileBytes(string telegramFilePath, HttpClient? httpClient = null)
    {
        return DoRequestAsync(httpClient, new GetFileBytesRequest($"{API_URL}file/{BotTokenPath}", telegramFilePath));
    }
    
    public async Task<List<Update>> GetUpdates(GetUpdatesParameters getUpdatesParameters, HttpClient? httpClient = null)
    {
        HttpResponseMessage httpResponseMessage =
            await DoRequestAsync(httpClient, new GetUpdatesRequest(API_URL + BotTokenPath, getUpdatesParameters));
        
        return JsonConvert.DeserializeObject<UpdateResponse>(
                   Regex.Unescape(httpResponseMessage.Content.ReadAsStringAsync().Result))?.Result 
               ?? new List<Update>();
    }
    
    private async Task<HttpResponseMessage> DoRequestWithLimiterAsync(HttpClient? httpClient, IExecutable request, string chatId)
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
            _requestLimiters.Add(chatId, new SendRequestLimiter());
        }
    }
    
    private SendRequestLimiter GetLimiter(string chatId)
    {
        return _requestLimiters[chatId];
    }
    
    private async Task<HttpResponseMessage> DoRequestAsync(HttpClient? httpClient, IExecutable request)
    {
        return await request.Execute(httpClient ?? new HttpClient());
    }
}