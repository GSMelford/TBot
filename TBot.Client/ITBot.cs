using TBot.Api.Telegram.DeleteMessage;
using TBot.Api.Telegram.EditMessage;
using TBot.Api.Telegram.GetFile;
using TBot.Api.Telegram.GetUpdates;
using TBot.Api.Telegram.SendMessage;
using TBot.Api.Telegram.SendVideo;
using Telegram.Dto.UpdateModule;

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