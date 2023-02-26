using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using TBot.Core.RequestLimiter.Interfaces;

namespace TBot.Core.RequestLimiter;

public class CallLimiter
{
    private readonly ILimiterStore _limiterStore;
    private readonly ILogger<CallLimiter>? _logger;
    private ConcurrentDictionary<string, Locker> CallLockers { get; } = new ();
    
    private readonly SemaphoreSlim _semaphore;
    private readonly LimiterConfig _limiterConfig;
    
    private static string LimiterContextKey (string key) => $"{key}:LimiterContext";

    public CallLimiter(ILimiterStore limiterStore, LimiterConfig limiterConfig, ILogger<CallLimiter>? logger = null)
    {
        _limiterStore = limiterStore;
        _limiterConfig = limiterConfig;
        _logger = logger;
        _semaphore = new SemaphoreSlim(_limiterConfig.ThreadInitialCount, _limiterConfig.ThreadMaxCount);
    }

    public async Task WaitAsync(string key)
    {
        await _semaphore.WaitAsync((int)_limiterConfig.ThreadTimeout.TotalMilliseconds);
        CallLockers.TryAdd(key, new Locker());
        
        while (true)
        {
            if (!await _limiterStore.LockTakeAsync(key))
            {
                Wait(CallLockers[key].LimiterStoreLock, _limiterConfig.StoreTimeout);
                continue;
            }
            
            LimiterContext limiterContext = await GetLimiterContextAsync(LimiterContextKey(key));
            try
            {
                if (limiterContext.HasNext())
                {
                    limiterContext.AddCall();
                    return;
                }

                TimeSpan waitInterval = limiterContext.GetWaitInterval();
                _logger?.LogInformation("Sending request blocked for {WaitInterval} due to the limit. " +
                                        "Request Key: {Key}", waitInterval, key);
                Console.WriteLine($"Sending request blocked for {waitInterval} due to the limit. Request Key: {key}");
                
                Wait(CallLockers[key].RequestLock, waitInterval);
                limiterContext.ClearCalls();

                _logger?.LogInformation("Sending request unblocked. Request Key: {Key}", key);
                Console.WriteLine($"Sending request unblocked. Request Key: {key}");
            }
            catch (Exception exception)
            {
                _logger?.LogError(exception, "Error processing limits. Request Key: {Key}", key);
                Console.WriteLine($"Error processing limits. Request Key: {key}");
            }
            finally
            {
                await UpdateLimiterContextAsync(LimiterContextKey(key), limiterContext);
                await _limiterStore.LockReleaseAsync(key);
                Wake(CallLockers[key].LimiterStoreLock);
            }
        }
    }

    public void Complete()
    {
        _semaphore.Release();
    }
    
    private async Task<LimiterContext> GetLimiterContextAsync(string key)
    {
        LimiterContext limiterContext;
        
        if (await _limiterStore.ContainsAsync(key))
        {
            limiterContext = (await _limiterStore.GetAsync(key))!;
        }
        else
        {
            limiterContext = new LimiterContext
            {
                MaxCalls = _limiterConfig.MaxCalls,
                Interval = _limiterConfig.CallsInterval
            };

            await _limiterStore.SetAsync(key, limiterContext);
            _logger?.LogInformation("Limit synchronization context successfully created. Request Key: {Key}", key);
            Console.WriteLine($"Limit synchronization context successfully created. Request Key: {key}");
        }

        return limiterContext;
    }

    private Task UpdateLimiterContextAsync(string key, LimiterContext limiterContext)
    {
        return _limiterStore.SetAsync(key, limiterContext);
    }
    
    private static void Wait(object lockObject, TimeSpan interval)
    {
        lock (lockObject)
        {
            Monitor.Wait(lockObject, interval);
        }
    }

    private static void Wake(object lockObject)
    {
        lock (lockObject) 
        {
            Monitor.PulseAll(lockObject);
        }
    }
}

public class Locker
{
    public readonly object RequestLock = new ();
    public readonly object LimiterStoreLock = new ();
}