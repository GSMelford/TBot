using TBot.Client.Interfaces;
using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Core.RequestLimiter.Interfaces;

namespace TBot.Client;

public class BotClient : ITBot
{
    private const string API_URL = "https://api.telegram.org";
    private readonly ITBotRequestService _tBotRequestService;
    private readonly ICallLimitService? _callLimitService;
    
    private readonly BotSettings _botToken;
    private string BaseUrl => $"{API_URL}/bot{_botToken.TelegramBotToken}";

    public BotClient(
        BotSettings botSettings,
        ITBotRequestService tBotRequestService, 
        ICallLimitService? callLimitService = null)
    {
        _botToken = botSettings;
        _tBotRequestService = tBotRequestService;
        _callLimitService = callLimitService;
    }

    public async Task<HttpResponseMessage> PostAsync(BaseRequest request, string? key = null)
    {
        if (_callLimitService is not null)
        {
            if (!string.IsNullOrEmpty(key))
            {
                await _callLimitService.WaitAsync(key);
            }
        }
        
        var response = await _tBotRequestService.SendAsync(request.Build(BaseUrl));
        return response;
    }
}