namespace TBot.Core.RequestArchitecture.Interfaces;

public interface IRequestSenderService
{
    public Task<HttpResponseMessage> SendAsync(HttpClient httpClient);
}