using TBot.Client.Api.DeleteMessage;
using TBot.Client.Api.EditMessage;
using TBot.Client.Api.GetUpdates;
using TBot.Client.Api.SendMessage;
using TBot.Client.Api.SendVideo;
using TBot.Client.Interfaces;
using TBot.Core.RequestArchitecture.Interfaces;

namespace TBot.Client;

public class TBotClient : ITBot
{
    private const string API_URL = "https://api.telegram.org";
    private readonly ITBotRequestService _itBotRequestService;
    
    private readonly TBotSettings _botToken;
    private string BaseUrl => $"{API_URL}/bot{_botToken.TelegramBotToken}";

    public TBotClient(TBotSettings botSettings, ITBotRequestService itBotRequestService)
    {
        _botToken = botSettings;
        _itBotRequestService = itBotRequestService;
    }

    public Task<HttpResponseMessage> SendMessageAsync(SendMessageParameters sendMessageParameters)
    {
        return _itBotRequestService.SendAsync(
            new SendMessageRequest(BaseUrl, sendMessageParameters).ToHttpRequestMessage());
    }

    public Task<HttpResponseMessage> SendVideoAsync(SendVideoParameters sendVideoParameters)
    {
        return _itBotRequestService.SendAsync(
            new SendVideoRequest(BaseUrl, sendVideoParameters).ToHttpRequestMessage());
    }

    public Task<HttpResponseMessage> EditMessageAsync(EditMessageParameters editMessageParameters)
    {
        return _itBotRequestService.SendAsync(
            new SendMessageRequest(BaseUrl, editMessageParameters).ToHttpRequestMessage());
    }
    
    public Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters)
    {
        return _itBotRequestService.SendAsync(
            new SendMessageRequest(BaseUrl, deleteMessageParameters).ToHttpRequestMessage());
    }
    
    public Task<HttpResponseMessage> GetUpdatesAsync(GetUpdatesParameter getUpdatesParameter)
    {
        return _itBotRequestService.SendAsync(
            new GetUpdatesRequest(BaseUrl, getUpdatesParameter).ToHttpRequestMessage());
    }
    
    //TODO: Move to other class
    /*private async Task<HttpResponseMessage> DoRequestWithLimiterAsync(HttpClient? httpClient, IRequestSenderService request, string chatId)
    {
        HttpResponseMessage? httpResponseMessage = null;
        AddLimiterIfNotExist(chatId);
        await GetLimiter(chatId).CheckAsync();
        
        try {
            httpResponseMessage = _requestSenderService.SendAsync(request);
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
    }*/
}