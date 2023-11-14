using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBot.Client.Domain.CallLimiter;
using TBot.Client.Domain.HttpRequests;
using TBot.Client.Domain.LongPolling;
using TBot.Client.Domain.TBot;
using TBot.Client.Options.CallLimiter.Redis;
using TBot.Client.Services.CallLimiter;
using TBot.Client.Services.CallLimiter.LimiterStores.Redis;
using TBot.Client.Services.HttpRequests;
using TBot.Client.Services.LongPolling;

namespace TBot.Client.AspNet;

// ReSharper disable once InconsistentNaming
public class TBotBuilder
{
    private readonly IServiceCollection _serviceCollection;
    private readonly IConfiguration _configuration;

    public TBotBuilder(WebApplicationBuilder webApplicationBuilder)
    {
        _serviceCollection = webApplicationBuilder.Services;
        _configuration = webApplicationBuilder.Configuration;

        ConfigureOptions();
        
        _serviceCollection
            .AddHttpClient<ITBotRequestService, TBotRequestService>().Services
            .AddTransient<ITBotClient, TBotClientClient>();
    }

    public TBotBuilder EnableCallLimiter(CallLimitStoreType storeType)
    {
        _serviceCollection.AddTransient<ICallLimiterService, CallLimiterService>();

        switch (storeType)
        {
            case CallLimitStoreType.Redis:
                _serviceCollection.AddTransient<ICallLimitStore, RedisCallLimitStore>();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(storeType), storeType, null);
        }

        return this;
    }
    
    public TBotBuilder AddLongPoll()
    {
        _serviceCollection.AddTransient<ILongPollingService, LongPollingService>();
        return this;
    }
    
    private void ConfigureOptions()
    {
        _serviceCollection.Configure<Options.TBotOptions>(_configuration.GetSection("TBotOptions"));
        _serviceCollection.Configure<RedisOption>(_configuration.GetSection("TBotOptions:RedisOption"));
        _serviceCollection.Configure<RedisOption>(_configuration.GetSection("TBotOptions:TBotLimiterOptions"));
    }
}