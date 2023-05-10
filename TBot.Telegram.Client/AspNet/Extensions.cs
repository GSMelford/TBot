using Microsoft.Extensions.DependencyInjection;
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
        BotSettings? botSettings = null,
        LimiterConfig? limiterConfig = null)
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

    public static IServiceCollection AddTBotRedisLimiter(
        this IServiceCollection serviceCollection, 
        string connectionString)
    {
        return serviceCollection
            .AddSingleton<ICallLimiterService, CallLimiterService>()
            .AddTransient<ICallLimitStore, RedisCallLimitStore>(_ => new RedisCallLimitStore(connectionString));
    }
}