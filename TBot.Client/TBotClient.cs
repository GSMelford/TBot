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
using TBot.Core.Interfaces;
using TBot.Telegram.Dto.Response;
using TBot.Telegram.Dto.UpdateModule;

namespace TBot.Client;

public class TBotClient : ITBot
{
    private readonly ILogger? _logger;
    private readonly HttpClient _httpClient;
    
    private readonly string _botToken;
    private const string API_URL = "https://api.telegram.org/";
    private string BotTokenPath => $"bot{_botToken}/";
    
    public TBotClient(string botToken, HttpClient httpClient, ILogger? logger = null)
    {
        _botToken = botToken;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<HttpResponseMessage> SendMessageAsync(SendMessageParameters sendMessageParameters)
    {
        return await DoRequestAsync(_httpClient, new SendMessageRequest(API_URL + BotTokenPath, sendMessageParameters));
    }

    public async Task<HttpResponseMessage> SendVideoAsync(SendVideoParameters sendVideoParameters)
    {
        return await DoRequestAsync(_httpClient, new SendVideoRequest(API_URL + BotTokenPath, sendVideoParameters));
    }

    public async Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters)
    {
        return await DoRequestAsync(_httpClient, new DeleteMessageRequest(API_URL + BotTokenPath, deleteMessageParameters));
    }
    
    public async Task<HttpResponseMessage> EditMessageAsync(EditMessageParameters editMessageParameters)
    {
        return await DoRequestAsync(_httpClient, new EditMessageRequest(API_URL + BotTokenPath, editMessageParameters));
    }

    public async Task<HttpResponseMessage> GetFileAsync(GetFileParameters getFileParameters)
    {
        return await DoRequestAsync(_httpClient, new GetFileRequest(API_URL + BotTokenPath, getFileParameters));
    }

    public async Task<HttpResponseMessage> GetFileBytes(string telegramFilePath)
    {
        return await DoRequestAsync(_httpClient, new GetFileBytesRequest($"{API_URL}file/{BotTokenPath}", telegramFilePath));
    }
    
    public async Task<List<Update>> GetUpdates(GetUpdatesParameters getUpdatesParameters)
    {
        HttpResponseMessage httpResponseMessage =
            await DoRequestAsync(_httpClient, new GetUpdatesRequest(API_URL + BotTokenPath, getUpdatesParameters));
        
        return JsonConvert.DeserializeObject<UpdateResponse>(
                   Regex.Unescape(httpResponseMessage.Content.ReadAsStringAsync().Result))?.Result 
               ?? new List<Update>();
    }

    private async Task<HttpResponseMessage> DoRequestAsync(HttpClient httpClient, IExecutable request)
    {
        _logger?.LogInformation("Sending {Type} Request", request.GetType());
        HttpResponseMessage response = await request.Execute(httpClient);
        
        _logger?.LogInformation(
            "Sent {Type} Request. StatusCode: {StatusCode}", request.GetType(), response.StatusCode.ToString());

        return response;
    }
}