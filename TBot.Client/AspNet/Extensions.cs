using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TBot.Client.Interfaces;
using Microsoft.AspNetCore.Routing;
using TBot.Telegram.Dto.Updates;

namespace TBot.Client.AspNet;

public static class Extensions
{
    
    
    
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
        return endpoints.UseTBot(options.UpdatePath, handler);
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
                if (update == null) {
                    throw new BadHttpRequestException("Couldn't deserialize an update dto.");
                }

                await handler(context, update);
            });
    }
}