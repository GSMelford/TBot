using Microsoft.Extensions.DependencyInjection;
using TBot.Client.Interfaces;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Core.Services;

namespace TBot.Client.Extensions;

public static class AspNetExtensions
{
    public static IServiceCollection AddTelegramTBot(this IServiceCollection serviceCollection, BotSettings botSettings)
    {
        return serviceCollection
            .AddSingleton(botSettings)
            .AddTransient<ITBot, BotClient>()
            .AddTransient<ITBotRequestService, TBotRequestService>();
    }
}