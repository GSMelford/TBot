using TBot.Client.Api.DeleteMessage;
using TBot.Client.Api.EditMessage;
using TBot.Client.Api.GetUpdates;
using TBot.Client.Api.SendMessage;
using TBot.Client.Api.SendVideo;

namespace TBot.Client.Interfaces;

public interface ITBot
{
    Task<HttpResponseMessage> SendMessageAsync(SendMessageParameters sendMessageParameters);
    Task<HttpResponseMessage> SendVideoAsync(SendVideoParameters sendVideoParameters);
    Task<HttpResponseMessage> EditMessageAsync(EditMessageParameters editMessageParameters);
    Task<HttpResponseMessage> DeleteMessageAsync(DeleteMessageParameters deleteMessageParameters);
    Task<HttpResponseMessage> GetUpdatesAsync(GetUpdatesParameter getUpdatesParameter);
}