using TBot.Client.AspNet;
using TBot.Client.Domain.CallLimiter;
using TBot.Client.Domain.Parameters;
using TBot.Client.Domain.TBot;
using TBot.Client.Domain.TBot.RequestIdentification;

var builder = WebApplication.CreateBuilder(args);

builder.AddTBot(botBuilder =>
    botBuilder.EnableCallLimiter(CallLimitStoreType.Redis));

var app = builder.Build();

app.UseTBot(async (_, provider, dto) =>
{
    var tBot = provider.GetRequiredService<ITBotClient>();
    await tBot.SendMessageAsync(new SendMessageParameters
    {
        Text = $"SessionId: {CurrentSessionThread.Session?.Id}\nChatId: {CurrentSessionThread.Session?.ChatId}\nMessage:{dto.Message!.Text}",
        ChatId = CurrentSessionThread.Session?.ChatId!
    });
});

await app.RunAsync();