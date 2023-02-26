using Microsoft.Extensions.DependencyInjection;

namespace TBot.Client.Extensions;

public static class AspNetExtensions
{
    public static IServiceCollection AddTelegramTBot(
        this IServiceCollection serviceCollection,  
        Func<BotBuilder, BotBuilder> bot)
    {
        bot(new BotBuilder(serviceCollection));
        return serviceCollection;
    }
}