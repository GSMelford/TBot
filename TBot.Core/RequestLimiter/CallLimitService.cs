using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using TBot.Core.RequestLimiter.Interfaces;

namespace TBot.Core.RequestLimiter;

public class CallLimitService : ICallLimitService
{
    private readonly ICallLimitStore _callLimitStore;
    private readonly ILogger<CallLimitService>? _logger;
    private ConcurrentDictionary<string, Locker> Lockers { get; } = new ();
    
    private readonly LimitConfig _limitConfig;
    
    private string CallLimitContextKey (string key) => $"{_limitConfig.StoreName}{key}:{nameof(CallLimitContext)}";

    public CallLimitService(
        ICallLimitStore callLimitStore,
        LimitConfig limitConfig,
        ILogger<CallLimitService>? logger = null)
    {
        _logger = logger;
        _callLimitStore = callLimitStore;
        _limitConfig = limitConfig;
    }

    public async Task WaitAsync(string key)
    {
        Lockers.TryAdd(key, new Locker());
        
        while (true)
        {
            if (!await _callLimitStore.LockTakeAsync(key))
            {
                Wait(Lockers[key].LimiterStoreLock, _limitConfig.StoreTimeout);
                continue;
            }
            
            var callLimiterSyncContext = await GetLimiterContextAsync(CallLimitContextKey(key));
            try
            {
                if (callLimiterSyncContext.HasNext())
                {
                    callLimiterSyncContext.SaveCall();
                    return;
                }

                TimeSpan waitInterval = callLimiterSyncContext.GetWaitInterval();
                _logger?.LogInformation("Sending request blocked for {WaitInterval} due to the limit. " +
                                        "Request Key: {Key}", waitInterval, key);
                
                Wait(Lockers[key].RequestLock, waitInterval);
                callLimiterSyncContext.Clear();

                _logger?.LogInformation("Sending request unblocked. Request Key: {Key}", key);
            }
            catch (Exception exception)
            {
                _logger?.LogError(exception, "Error processing limits. Request Key: {Key}", key);
            }
            finally
            {
                await UpdateCallLimitContextAsync(CallLimitContextKey(key), callLimiterSyncContext);
                await _callLimitStore.LockReleaseAsync(key);
                Wake(Lockers[key].LimiterStoreLock);
            }
        }
    }
    
    private async Task<CallLimitContext> GetLimiterContextAsync(string key)
    {
        CallLimitContext callLimitContext;
        
        if (await _callLimitStore.ContainsAsync(key))
        {
            callLimitContext = (await _callLimitStore.GetAsync(key))!;
        }
        else
        {
            callLimitContext = new CallLimitContext
            {
                MaxCalls = _limitConfig.MaxCalls,
                Interval = _limitConfig.CallsInterval
            };

            await _callLimitStore.SetAsync(key, callLimitContext);
            _logger?.LogInformation("Limit synchronization context successfully created. Request Key: {Key}", key);
        }

        return callLimitContext;
    }

    private Task UpdateCallLimitContextAsync(string key, CallLimitContext callLimitContext)
    {
        return _callLimitStore.SetAsync(key, callLimitContext);
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