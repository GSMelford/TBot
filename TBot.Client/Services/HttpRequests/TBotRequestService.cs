using TBot.Client.Domain.HttpRequests;

namespace TBot.Client.Services.HttpRequests;

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