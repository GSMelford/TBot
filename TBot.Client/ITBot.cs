using TBot.Client.Api.Telegram.DeleteMessage;
using TBot.Client.Api.Telegram.EditMessage;
using TBot.Client.Api.Telegram.GetFile;
using TBot.Client.Api.Telegram.GetUpdates;
using TBot.Client.Api.Telegram.SendMessage;
using TBot.Client.Api.Telegram.SendVideo;
using TBot.Telegram.Dto;

namespace TBot.Client;

public interface ITBot
{
    Task<List<Update>> GetUpdates(GetUpdatesParameters getUpdatesParameters, HttpClient? httpClient = null);
    Task<HttpResponseMessage> SendMessageAsync(SendMessageParameters sendMessageParameters, HttpClient? httpClient = null);
    Task<HttpResponseMessage> SendVideoAsync(SendVideoParameters sendVideoParameters, HttpClient? httpClient = null);
    Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters, HttpClient? httpClient = null);
    Task<HttpResponseMessage> EditMessageAsync(EditMessageParameters editMessageParameters, HttpClient? httpClient = null);
    Task<HttpResponseMessage> GetFileAsync(GetFileParameters getFileParameters, HttpClient? httpClient = null);
    Task<HttpResponseMessage> GetFileBytes(string telegramFilePath, HttpClient? httpClient = null);
}