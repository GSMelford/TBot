using TBot.Client.Interfaces;
using TBot.Client.Parameters;
using TBot.Client.Requests;
using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Core.Utilities;
using TBot.Telegram.Dto.Types;
using TBot.Telegram.Dto.Types.Responses;
using TBot.Telegram.Dto.Updates.Methods;

namespace TBot.Client;

public class BotClient : ITBot
{
    private const string API_URL = "https://api.telegram.org";
    private readonly ITBotRequestService _tBotRequestService;
    
    private readonly BotSettings _botToken;
    private string BaseUrl => $"{API_URL}/bot{_botToken.TelegramBotToken}";

    public BotClient(BotSettings botSettings, ITBotRequestService tBotRequestService)
    {
        _botToken = botSettings;
        _tBotRequestService = tBotRequestService;
    }

    public Task<HttpResponseMessage> PostAsync(Request request)
    {
        return _tBotRequestService.SendAsync(new BaseRequest(BaseUrl, request).Build());
    }

    public async Task<ResponseDto<MessageDto>> SendMessageAsync(SendMessageParameters sendMessageParameters)
    {
        return (await _tBotRequestService.SendAsync(
                new SendMessageRequest(BaseUrl, sendMessageParameters).Build()))
            .ToRequiredObject<ResponseDto<MessageDto>>();
    }

    public Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters)
    {
        return _tBotRequestService.SendAsync(
            new SendMessageRequest(BaseUrl, deleteMessageParameters).Build());
    }
    
    public Task<HttpResponseMessage> GetUpdatesAsync(GetUpdatesParameters getUpdatesParameters)
    {
        return _tBotRequestService.SendAsync(
            new GetUpdatesRequest(BaseUrl, getUpdatesParameters).Build());
    }
    
    public Task<HttpResponseMessage> DeleteWebhookAsync(DeleteWebhookParameters deleteWebhookParameters)
    {
        return _tBotRequestService.SendAsync(
            new DeleteMessageRequest(BaseUrl, deleteWebhookParameters).Build());
    }
    
    public Task<HttpResponseMessage> SetWebhookAsync(SetWebhookParameters setWebhookParameters)
    {
        return _tBotRequestService.SendAsync(
            new SetWebhookRequest(BaseUrl, setWebhookParameters).Build());
    }
}