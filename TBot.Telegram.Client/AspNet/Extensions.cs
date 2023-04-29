using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        Func<BotBuilder, BotBuilder> bot,
        bool enableLimiter = false)
    {
        serviceCollection
            .AddHttpClient<ITBotRequestService, TBotRequestService>().Services
            .AddTransient<ITBot>(provider =>
            {
                var requestService = provider.GetRequiredService<ITBotRequestService>();
                var callLimitService = provider.GetService<ICallLimitService>();

                var botBuilder = bot(new BotBuilder());

                return new BotClient(botBuilder.BotSettings, requestService, callLimitService);
            });

        if (enableLimiter)
        {
            serviceCollection
                .AddSingleton<ICallLimitService, CallLimitService>(provider =>
                {
                    var callLimiterStore = provider.GetRequiredService<ICallLimitStore>();
                    var logger = provider.GetRequiredService<ILogger<ICallLimitService>>();
                    var botBuilder = bot(new BotBuilder());
                    return new CallLimitService(callLimiterStore, botBuilder.LimiterConfig, logger);
                })
                .AddTransient<ICallLimitStore>(_ =>
                {
                    var botBuilder = bot(new BotBuilder());

                    return botBuilder.LimitStore switch
                    {
                        LimitStore.Redis => new RedisCallLimitStore(botBuilder.RedisConnectionString!),
                        LimitStore.Memory => throw new ArgumentOutOfRangeException(),
                        LimitStore.File => throw new ArgumentOutOfRangeException(),
                        null => throw new ArgumentOutOfRangeException(),
                        _ => throw new ArgumentOutOfRangeException()
                    };
                });
        }

        return serviceCollection;
    }
}