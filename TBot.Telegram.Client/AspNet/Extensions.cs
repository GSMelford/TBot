using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TBot.Client.Interfaces;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Core.RequestLimiter;
using TBot.Core.RequestLimiter.Interfaces;
using TBot.Core.RequestLimiter.LimiterStores;
using TBot.Core.Services;

namespace TBot.Client.AspNet;

public static class Extensions
{
    public static IServiceCollection AddTelegramTBot(
        this IServiceCollection serviceCollection,
        TBotOptions? botSettings = null,
        TBotLimiterOptions? limiterConfig = null)
    {
        return serviceCollection
            .AddHttpClient<ITBotRequestService, TBotRequestService>().Services
            .AddTransient<ITBot, BotClient>(provider =>
            {
                var requestService = provider.GetRequiredService<ITBotRequestService>();
                var callLimiterService = provider.GetService<ICallLimiterService>();
                var bot = new BotClient(requestService, callLimiterService);
                bot.Init(botSettings, limiterConfig);
                return bot;
            });
    }

    public static IServiceCollection AddTelegramTBot(this IServiceCollection services, Action<TBotOptions>? setupAction)
    {
        services.AddTransient<ITBot, BotClient>(sp =>
        {
            var requestService = sp.GetRequiredService<ITBotRequestService>();
            var callLimiterService = sp.GetService<ICallLimiterService>();
            
            var bot = new BotClient(requestService, callLimiterService);
            var botOptions = sp.GetRequiredService<IOptionsSnapshot<TBotOptions>>().Value;
            var limiterOptions = sp.GetService<IOptionsSnapshot<TBotLimiterOptions>>()?.Value;
            bot.Init(botOptions, limiterOptions);
            return bot;
        });

        if (setupAction != null)
            services.Configure(setupAction);

        return services;
    }

    public static IServiceCollection AddTBotRedisLimiter(
        this IServiceCollection services, 
        string connectionString)
    {
        return services
            .AddSingleton<ICallLimiterService, CallLimiterService>()
            .AddTransient<ICallLimitStore, RedisCallLimitStore>(_ => new RedisCallLimitStore(connectionString));
    }
    
    public static IServiceCollection AddTBotRedisLimiter(
        this IServiceCollection services, 
        Action<TBotLimiterOptions>? action)
    {
        services
            .AddSingleton<ICallLimiterService, CallLimiterService>()
            .AddTransient<ICallLimitStore, RedisCallLimitStore>(sp =>
            {
                var limiterOptions = sp.GetRequiredService<IOptionsSnapshot<TBotLimiterOptions>>().Value;
                return new RedisCallLimitStore(limiterOptions.StoreConnectionString!);
            });
        
        if (action != null)
            services.Configure(action);

        return services;
    }
}