using TBot.Client.Domain.HttpRequests;

namespace TBot.Client.Interfaces;

public interface ITBot
{
    Task<HttpResponseMessage> SendAsync(RequestDescriptor request);
}