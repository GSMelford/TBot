using TBot.Client;
using TBot.Client.Domain.HttpRequests;
using TBot.Client.Domain.Parameters;
using TBot.Client.Interfaces;
using TBot.Client.Interfaces.LongPolling;
using TBot.Client.Services.HttpRequests;
using TBot.Client.Services.LongPolling;
using TBot.Telegram.Dto.Updates;

Console.WriteLine("Hello, Telegram Bot!");

ITBotRequestService requestService = new TBotRequestService(new HttpClient());
ITelegramBot bot = new TelegramBot(requestService, new BotOptions
{
    BotToken = ""
});

var receiveService = new ReceiveService(bot, new UpdateService(bot));
receiveService.StartGettingUpdate();

while (true)
{
    if (Console.ReadKey().Key == ConsoleKey.E)
    {
        receiveService.StopGettingUpdate();
        return;
    }
}

internal class UpdateService : IUpdateService
{
    private readonly ITelegramBot _telegramBot;

    public UpdateService(ITelegramBot telegramBot)
    {
        _telegramBot = telegramBot;
    }

    public async Task UpdateAsync(UpdateDto updateDto)
    {
        Console.WriteLine($"Client: {updateDto.Message?.Text}");
        await _telegramBot.SendMessageAsync(new SendMessageParameters
        {
            Text = $"Your message: {updateDto.Message?.Text}",
            ChatId = updateDto.Message!.From!.Id
        });
    }
}