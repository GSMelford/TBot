using TBot.Client.Parameters;
using TBot.Core.RequestArchitecture;
using TBot.Telegram.Dto.Types;
using TBot.Telegram.Dto.Types.Responses;
using TBot.Telegram.Dto.Updates.Methods;

namespace TBot.Client.Interfaces;

public interface ITBot
{
    Task<HttpResponseMessage> PostAsync(Request request);
    Task<ResponseDto<MessageDto>> SendMessageAsync(SendMessageParameters sendMessageParameters);
    Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters);
    Task<HttpResponseMessage> GetUpdatesAsync(GetUpdatesParameters getUpdatesParameters);
    Task<HttpResponseMessage> DeleteWebhookAsync(DeleteWebhookParameters deleteWebhookParameters);
    Task<HttpResponseMessage> SetWebhookAsync(SetWebhookParameters setWebhookParameters);
}