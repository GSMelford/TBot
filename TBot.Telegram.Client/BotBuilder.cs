using Microsoft.Extensions.DependencyInjection;
using TBot.Client.Interfaces;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Core.RequestLimiter;
using TBot.Core.RequestLimiter.Interfaces;
using TBot.Core.RequestLimiter.LimiterStores;
using TBot.Core.Services;

namespace TBot.Client;

public class BotBuilder
{
    private readonly IServiceCollection _serviceCollection;

    private readonly LimitConfig _defaultLimitConfig = new ()
    {
        CallsInterval = TimeSpan.FromSeconds(60),
        MaxCalls = 20,
        StoreTimeout = TimeSpan.FromSeconds(2),
        ThreadTimeout = TimeSpan.FromSeconds(30),
        ThreadInitialCount = 20,
        ThreadMaxCount = 20
    };
    
    public BotBuilder(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
        _serviceCollection.AddTransient<ITBot, BotClient>();
        _serviceCollection.AddHttpClient<ITBotRequestService, TBotRequestService>();
    }

    public BotBuilder AddSettings(BotSettings botSettings)
    {
        botSettings.Validate();
        _serviceCollection.AddSingleton(botSettings);
        return this;
    }
    
    public BotBuilder AddLimiter(LimitStore limitStore, LimitConfig? limitConfig = null)
    {
        limitConfig ??= _defaultLimitConfig;
        limitConfig.Validate(20, TimeSpan.FromSeconds(60));
        
        _serviceCollection.AddSingleton(limitConfig);
        _serviceCollection.AddSingleton<ICallLimitService, CallLimitService>();

        switch (limitStore)
        {
            case LimitStore.Redis:
                _serviceCollection.AddTransient<ICallLimitStore, RedisCallLimitStore>();
                break;
            case LimitStore.Memory:
                break;
            case LimitStore.File:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(limitStore), limitStore, null);
        }
        
        return this;
    }
}