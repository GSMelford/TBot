namespace TBot.Client.Domain.HttpRequests;

public interface ITBotRequestService
{
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
}