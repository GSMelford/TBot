using TBot.Client.Interfaces;
using TBot.Client.Requests;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Telegram.Dto.Methods;
using TBot.Telegram.Dto.Updates.Methods;

namespace TBot.Client;

public class BotClient : ITBot
{
    private const string API_URL = "https://api.telegram.org";
    private readonly ITBotRequestService _itBotRequestService;
    
    private readonly BotSettings _botToken;
    private string BaseUrl => $"{API_URL}/bot{_botToken.TelegramBotToken}";

    public BotClient(BotSettings botSettings, ITBotRequestService itBotRequestService)
    {
        _botToken = botSettings;
        _itBotRequestService = itBotRequestService;
    }

    public Task<HttpResponseMessage> SendMessageAsync(SendMessageParameters sendMessageParameters)
    {
        return _itBotRequestService.SendAsync(
            new SendMessageRequest(BaseUrl, sendMessageParameters).ToHttpRequestMessage());
    }

    public Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters)
    {
        return _itBotRequestService.SendAsync(
            new SendMessageRequest(BaseUrl, deleteMessageParameters).ToHttpRequestMessage());
    }
    
    public Task<HttpResponseMessage> GetUpdatesAsync(GetUpdatesParameters getUpdatesParameters)
    {
        return _itBotRequestService.SendAsync(
            new GetUpdatesRequest(BaseUrl, getUpdatesParameters).ToHttpRequestMessage());
    }
    
    public Task<HttpResponseMessage> DeleteWebhookAsync(DeleteWebhookParameters deleteWebhookParameters)
    {
        return _itBotRequestService.SendAsync(
            new DeleteMessageRequest(BaseUrl, deleteWebhookParameters).ToHttpRequestMessage());
    }
    
    public Task<HttpResponseMessage> SetWebhookAsync(SetWebhookParameters setWebhookParameters)
    {
        return _itBotRequestService.SendAsync(
            new SetWebhookRequest(BaseUrl, setWebhookParameters).ToHttpRequestMessage());
    }
    
    //TODO: getWebhookInfo - Don't Forget About Method Development. Watch here => https://core.telegram.org/bots/api#getwebhookinfo

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