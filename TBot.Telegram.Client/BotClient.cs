using TBot.Client.Interfaces;
using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Interfaces;

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

    public Task<HttpResponseMessage> PostAsync(BaseRequest request)
    {
        return _tBotRequestService.SendAsync(request.Build(BaseUrl));
    }
}