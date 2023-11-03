using TBot.Client;
using TBot.Client.Parameters;
using TBot.Client.RequestArchitecture.Interfaces;
using TBot.Client.Services.HttpRequests;

Console.WriteLine("Hello, Telegram Bot!");

ITBotRequestService requestService = new TBotRequestService(new HttpClient());
var bot = new TelegramBot(requestService, new TBotOptions
{
    BotToken = ""
});

var result = await bot.SendMessageAsync(new SendMessageParameters
{
    Text = "Hi!",
    ChatId = 0
});

Console.WriteLine(result.Response.Result?.Text);