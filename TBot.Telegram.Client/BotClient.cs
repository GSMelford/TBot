using TBot.Client.Interfaces;
using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Core.RequestLimiter.Interfaces;

namespace TBot.Client;

public class BotClient : ITBot
{
    private const string API_URL = "https://api.telegram.org";
    private readonly ITBotRequestService _tBotRequestService;
    private readonly IServiceProvider _serviceProvider;
    
    private readonly BotSettings _botToken;
    private string BaseUrl => $"{API_URL}/bot{_botToken.TelegramBotToken}";

    public BotClient(
        BotSettings botSettings,
        ITBotRequestService tBotRequestService, 
        IServiceProvider serviceProvider)
    {
        _botToken = botSettings;
        _tBotRequestService = tBotRequestService;
        _serviceProvider = serviceProvider;
    }

    public async Task<HttpResponseMessage> PostAsync(BaseRequest request, string? key = null)
    {
        object? service = _serviceProvider.GetService(typeof(ICallLimitService));
        ICallLimitService? callLimitService = null;
        
        if (service is ICallLimitService limitService)
        {
            callLimitService = limitService;
            if (!string.IsNullOrEmpty(key))
            {
                await callLimitService.WaitAsync(key);
            }
        }
        
        HttpResponseMessage response = await _tBotRequestService.SendAsync(request.Build(BaseUrl));
        callLimitService?.Complete();
        
        return response;
    }
}