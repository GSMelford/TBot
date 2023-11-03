namespace TBot.Client.RequestArchitecture.Interfaces;

public interface ITBotRequestService
{
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
}