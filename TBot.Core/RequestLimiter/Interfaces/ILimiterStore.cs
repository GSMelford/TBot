using TBot.Core.RequestLimiter.LimiterStores;

namespace TBot.Core.RequestLimiter.Interfaces;

public interface ILimiterStore
{
    Task<bool> LockTakeAsync(string key);
    Task<bool> LockReleaseAsync(string key);
    Task<LimiterContext?> GetAsync(string key);
    Task SetAsync(string key, LimiterContext limiterContext, TimeSpan? timeToLive = null);
    Task<bool> ContainsAsync(string key);
}