using StackExchange.Redis;
using TBot.Core.RequestLimiter.Interfaces;
using TBot.Core.Utilities;

namespace TBot.Core.RequestLimiter.LimiterStores;

public class RedisLimiterStore : ILimiterStore
{
    private readonly IDatabase _redisDatabase;

    public RedisLimiterStore(string configurationString)
    {
        IConnectionMultiplexer connection = ConnectionMultiplexer.Connect(configurationString);
        _redisDatabase = connection.GetDatabase();
    }

    public async Task<bool> LockTakeAsync(string key)
    {
        return await _redisDatabase.LockTakeAsync($"{key}:Lock", key, TimeSpan.FromMinutes(10));
    }

    public Task<bool> LockReleaseAsync(string key)
    {
        return _redisDatabase.LockReleaseAsync($"{key}:Lock", key);
    }
    
    public async Task<LimiterContext?> GetAsync(string key)
    {
        string value = (await _redisDatabase.StringGetAsync(key)).ToString();
        return string.IsNullOrEmpty(value) ? default : value.ToObject<LimiterContext>();
    }
    
    public Task SetAsync(string key, LimiterContext limiterContext, TimeSpan? timeToLive = null) 
    {
        return _redisDatabase.StringSetAsync(key, limiterContext.ToJson(), timeToLive);
    }
    
    public Task<bool> ContainsAsync(string key) 
    {
        return _redisDatabase.KeyExistsAsync(key);
    }
}