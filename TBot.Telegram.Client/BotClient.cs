using TBot.Client.Interfaces;
using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Core.RequestLimiter;
using TBot.Core.RequestLimiter.Interfaces;

namespace TBot.Client;

public class BotClient : ITBot
{
    private const string API_URL = "https://api.telegram.org";
    private readonly ITBotRequestService _tBotRequestService;
    private readonly ICallLimiterService? _callLimitService;

    private BotSettings? _botSettings;
    private LimiterConfig? _limitConfig;
    
    private static string GetBaseUrl (string token) => $"{API_URL}/bot{token}";

    public BotClient(
        ITBotRequestService tBotRequestService, 
        ICallLimiterService? callLimitService = null)
    {
        _tBotRequestService = tBotRequestService;
        _callLimitService = callLimitService;
    }

    public void Init(BotSettings? botSettings = null, LimiterConfig? limitConfig = null)
    {
        _botSettings = botSettings;
        _limitConfig = limitConfig;
        _limitConfig ??= new LimiterConfig
        {
            StoreName = "Default",
            CallsInterval = TimeSpan.FromSeconds(60),
            MaxCalls = 20,
            StoreTimeout = TimeSpan.FromSeconds(2),
            ThreadTimeout = TimeSpan.FromSeconds(30),
            ThreadInitialCount = 20,
            ThreadMaxCount = 20
        };
    }

    public Task<HttpResponseMessage> PostAsync(BaseRequest request)
    {
        ValidateBotSettings();
        return _tBotRequestService.SendAsync(request.Build(GetBaseUrl(_botSettings!.BotToken)));
    }
    
    public async Task<HttpResponseMessage> PostWithLimiterAsync(BaseRequest request, string limiterKey)
    {
        ValidateBotSettings();
        await _callLimitService!.WaitAsync(limiterKey, _limitConfig!); 
        return await _tBotRequestService.SendAsync(request.Build(GetBaseUrl(_botSettings!.BotToken)));
    }

    private void ValidateBotSettings()
    {
        if (_botSettings is null) {
            throw new Exception("Bot settings not set!");
        }
    }
}