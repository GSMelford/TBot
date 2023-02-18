using TBot.Telegram.Dto.Methods;
using TBot.Telegram.Dto.Updates.Methods;

namespace TBot.Client.Interfaces;

public interface ITBot
{
    Task<HttpResponseMessage> SendMessageAsync(SendMessageParameters sendMessageParameters);
    Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters);
    Task<HttpResponseMessage> GetUpdatesAsync(GetUpdatesParameters getUpdatesParameters);
    Task<HttpResponseMessage> DeleteWebhookAsync(DeleteWebhookParameters deleteWebhookParameters);
    Task<HttpResponseMessage> SetWebhookAsync(SetWebhookParameters setWebhookParameters);
}