using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TBot.Client;

public static class TBotExtensions
{
    public static void AddTBotClient(this IServiceCollection serviceCollection, string botToken)
    {
        serviceCollection.AddTransient<ITBot, TBotClient>(provider => 
            new TBotClient(
                botToken, 
                provider.GetRequiredService<HttpClient>(), 
                provider.GetRequiredService<ILogger<ITBot>>()));
    }
}