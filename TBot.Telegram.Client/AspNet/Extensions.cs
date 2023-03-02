using Microsoft.Extensions.DependencyInjection;

namespace TBot.Client.AspNet;

public static class Extensions
{
    public static IServiceCollection AddTelegramTBot(
        this IServiceCollection serviceCollection,  
        Func<BotBuilder, BotBuilder> bot)
    {
        bot(new BotBuilder(serviceCollection));
        return serviceCollection;
    }
}