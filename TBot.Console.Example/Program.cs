using Microsoft.Extensions.Options;
using TBot.Client;
using TBot.Client.Domain.LongPolling;
using TBot.Client.Domain.Parameters;
using TBot.Client.Domain.TBot;
using TBot.Client.Options;
using TBot.Client.Options.CallLimiter.Redis;
using TBot.Client.Services.CallLimiter;
using TBot.Client.Services.CallLimiter.LimiterStores.Redis;
using TBot.Client.Services.HttpRequests;
using TBot.Client.Services.LongPolling;

var tBotOption = new OptionsWrapper<TBotOptions>(new TBotOptions { Token = "" });
var limitConfig = new OptionsWrapper<CallLimiterOptions>(new CallLimiterOptions { StoreName = "TBot" });

var requestService = new TBotRequestService(new HttpClient());
var callService = new CallLimiterService(new RedisCallLimitStore(new OptionsWrapper<RedisOption>(new RedisOption
{
    Host = "",
    Password = "",
    DefaultDatabase = 1,
    SyncTimeout = 1
})));

ITBotClient tBot = new TBotClientClient(tBotOption, requestService, limitConfig, callService);
ILongPollingService longPollingService = new LongPollingService(tBot);

longPollingService.Start(async dto =>
{
    await tBot.SendMessageAsync(new SendMessageParameters
    {
        Text = $"You: {dto.Message!.Text!}",
        ChatId = dto.Message.From!.Id
    });
});

Console.ReadKey();