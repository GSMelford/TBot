using TBot.Core.RequestArchitecture;

namespace TBot.Client.Interfaces;

public interface ITBot
{
    Task<HttpResponseMessage> PostAsync(BaseRequest request);
}