using TBot.Core.RequestArchitecture.Interfaces;

namespace TBot.Core.Services;

public class TBotRequestService : ITBotRequestService
{
    private readonly HttpClient _httpClient;

    public TBotRequestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
    {
        return await _httpClient.SendAsync(request);
    }
}