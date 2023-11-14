using TBot.Client.AspNet;
using TBot.Client.Domain.CallLimiter;
using TBot.Client.Domain.Parameters;
using TBot.Client.Domain.TBot;

var builder = WebApplication.CreateBuilder(args);

builder.AddTBot(botBuilder =>
    botBuilder.EnableCallLimiter(CallLimitStoreType.Redis));

var app = builder.Build();

app.UseTBot(async (_, provider, dto) =>
{
    var tBot = provider.GetRequiredService<ITBotClient>();
    await tBot.SendMessageAsync(new SendMessageParameters
    {
        Text = $"You: {dto.Message!.Text!}",
        ChatId = dto.Message.From!.Id
    });
});

await app.RunAsync();