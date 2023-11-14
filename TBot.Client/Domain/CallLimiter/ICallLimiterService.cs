using TBot.Client.Services.CallLimiter;

namespace TBot.Client.Domain.CallLimiter;

public interface ICallLimiterService
{
    Task WaitAsync(string key, CallLimiterOptions callLimiterOptions);
}