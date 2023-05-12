using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TBot.Client.Interfaces;
using TBot.Core.RequestArchitecture.Interfaces;
using TBot.Core.RequestLimiter;
using TBot.Core.RequestLimiter.Interfaces;
using TBot.Core.RequestLimiter.LimiterStores;
using TBot.Core.Services;
using Microsoft.AspNetCore.Routing;
using TBot.Telegram.Dto.Updates;

namespace TBot.Client.AspNet;

public static class Extensions
{
    public static IServiceCollection AddTelegramTBot(
        this IServiceCollection serviceCollection,
        TBotOptions? botSettings = null,
        TBotLimiterOptions? limiterConfig = null)
    {
        return serviceCollection
            .AddHttpClient<ITBotRequestService, TBotRequestService>()
            .Services.AddTransient<ITBot, BotClient>(provider =>
            {
                var requestService = provider.GetRequiredService<ITBotRequestService>();
                var callLimiterService = provider.GetService<ICallLimiterService>();
                var bot = new BotClient(requestService, callLimiterService);
                bot.Init(botSettings, limiterConfig);
                return bot;
            });
    }

    public static IServiceCollection AddTelegramTBotConfigure(
        this WebApplicationBuilder applicationBuilder,
        Action<TBotOptions>? setupAction = null)
    {
        var services = applicationBuilder.Services;
        services.AddHttpClient<ITBotRequestService, TBotRequestService>()
            .Services.AddTransient<ITBot, BotClient>(sp =>
            {
                using var scope = sp.CreateScope();
                var requestService = scope.ServiceProvider.GetRequiredService<ITBotRequestService>();
                var callLimiterService = scope.ServiceProvider.GetService<ICallLimiterService>();

                var bot = new BotClient(requestService, callLimiterService);
                var botOptions = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TBotOptions>>().Value;
                var limiterOptions = scope.ServiceProvider.GetService<IOptionsSnapshot<TBotLimiterOptions>>()?.Value;
                bot.Init(botOptions, limiterOptions);
                return bot;
            });

        if (setupAction != null)
            services.Configure(setupAction);
        else
            services.Configure<TBotOptions>(applicationBuilder.Configuration.GetSection("TBot"));

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
        this WebApplicationBuilder applicationBuilder,
        Action<TBotLimiterOptions>? action = null)
    {
        var services = applicationBuilder.Services
            .AddSingleton<ICallLimiterService, CallLimiterService>()
            .AddTransient<ICallLimitStore, RedisCallLimitStore>(sp =>
            {
                using var scope = sp.CreateScope();
                var limiterOptions = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TBotLimiterOptions>>().Value;
                return new RedisCallLimitStore(limiterOptions.StoreConnectionString);
            });
        
        if (action != null)
            services.Configure(action);
        else
            services.Configure<TBotLimiterOptions>(applicationBuilder.Configuration.GetSection("TBot"));

        return services;
    }

    public static IEndpointConventionBuilder UseTBot(
        this IEndpointRouteBuilder endpoints,
        Func<HttpContext, UpdateDto, Task> handler)
    {
        using var scope = endpoints.ServiceProvider.CreateScope();
        var pattern = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TBotOptions>>().Value.UpdatePath;
        return endpoints.UseTBot(pattern, handler);
    }

    public static IEndpointConventionBuilder UseTBot(
        this IEndpointRouteBuilder endpoints,
        Action<TBotOptions> optionAction,
        Func<HttpContext, UpdateDto, Task> handler)
    {
        using var scope = endpoints.ServiceProvider.CreateScope();
        var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TBotOptions>>().Value;
        optionAction(options);
        return endpoints.UseTBot(options.BotToken, handler);
    }

    private static IEndpointConventionBuilder UseTBot(
        this IEndpointRouteBuilder endpoints,
        [StringSyntax("Route")] string pattern, 
        Func<HttpContext, UpdateDto, Task> handler)
    {
        return endpoints.MapPost(pattern,
            async context =>
            {
                var update = await JsonSerializer.DeserializeAsync<UpdateDto>(context.Request.Body);
                if (update == null)
                    throw new BadHttpRequestException("Couldn't deserialize an update dto.");
                await handler(context, update);
            });
    }
}