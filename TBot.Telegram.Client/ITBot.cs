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
    Task<List<Update>> GetUpdates(GetUpdatesParameter getUpdatesParameter, HttpClient? httpClient = null);
    Task<HttpResponseMessage> SendMessageAsync(SendMessageParameter sendMessageParameter, HttpClient? httpClient = null);
    Task<HttpResponseMessage> SendVideoAsync(SendVideoParameter sendVideoParameter, HttpClient? httpClient = null);
    Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameter deleteMessageParameter, HttpClient? httpClient = null);
    Task<HttpResponseMessage> EditMessageAsync(EditMessageParameter editMessageParameter, HttpClient? httpClient = null);
    Task<HttpResponseMessage> GetFileAsync(GetFileParameter getFileParameter, HttpClient? httpClient = null);
    Task<HttpResponseMessage> GetFileBytes(string telegramFilePath, HttpClient? httpClient = null);
}