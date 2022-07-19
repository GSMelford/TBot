using TBot.Client.Api.Telegram.DeleteMessage;
using TBot.Client.Api.Telegram.EditMessage;
using TBot.Client.Api.Telegram.GetFile;
using TBot.Client.Api.Telegram.GetUpdates;
using TBot.Client.Api.Telegram.SendMessage;
using TBot.Client.Api.Telegram.SendVideo;
using TBot.Telegram.Dto.UpdateModule;

namespace TBot.Client;

public interface ITBot
{
    Task<List<Update>> GetUpdates(GetUpdatesParameters getUpdatesParameters);
    Task<HttpResponseMessage> SendMessageAsync(SendMessageParameters sendMessageParameters);
    Task<HttpResponseMessage> SendVideoAsync(SendVideoParameters sendVideoParameters);
    Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters);
    Task<HttpResponseMessage> EditMessageAsync(EditMessageParameters editMessageParameters);
    Task<HttpResponseMessage> GetFileAsync(GetFileParameters getFileParameters);
    Task<HttpResponseMessage> GetFileBytes(string telegramFilePath);
}