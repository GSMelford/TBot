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
        _serviceCollection.AddHttpClient<ITBotRequestService, TBotRequestService>();
    }

    public BotBuilder AddBot(BotSettings botSettings)
    {
        botSettings.Validate();
        _serviceCollection.AddTransient<ITBot, BotClient>(provider =>
        {
            var requestService = provider.GetRequiredService<ITBotRequestService>();
            var callLimitService = provider.GetService<ICallLimitService>();
            return new BotClient(botSettings, requestService, callLimitService);
        });
        _serviceCollection.AddSingleton(botSettings);
        return this;
    }
    
    public BotBuilder AddRedisLimiter(string redisConnectionString, LimitConfig? limitConfig = null)
    {
        AddLimiter(limitConfig);
        _serviceCollection.AddTransient<ICallLimitStore, RedisCallLimitStore>(_ => new RedisCallLimitStore(redisConnectionString));
        return this;
    }
    
    private BotBuilder AddLimiter(LimitConfig? limitConfig = null)
    {
        limitConfig ??= _defaultLimitConfig;
        limitConfig.Validate(20, TimeSpan.FromSeconds(60));
        
        _serviceCollection.AddSingleton(limitConfig);
        _serviceCollection.AddSingleton<ICallLimitService, CallLimitService>();

        return this;
    }
}