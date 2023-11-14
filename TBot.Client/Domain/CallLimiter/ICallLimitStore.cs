namespace TBot.Client.Domain.CallLimiter;

public interface ICallLimitStore
{
    Task<bool> LockTakeAsync(string key);
    Task<bool> LockReleaseAsync(string key);
    Task<CallLimitContext?> GetAsync(string key);
    Task SetAsync(string key, CallLimitContext callLimitContext, TimeSpan? timeToLive = null);
    Task<bool> ContainsAsync(string key);
}