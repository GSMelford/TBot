namespace TBot.Client;

public class SendRequestLimiter
{
    private const int MAX_CALLS = 20;
    private int _callsCounter;
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);
    
    private readonly object _lockObject = new ();
    private bool _isWait;
    
    private readonly SemaphoreSlim _semaphore = new (MAX_CALLS, MAX_CALLS);

    public async Task CheckAsync()
    {
        await _semaphore.WaitAsync((int)_interval.TotalMilliseconds * 10);

        try {
            if (CompareNumberOfRequests()) {
                return;
            }

            if (WaitInQueueIfNeeded()) {
                return;
            }

            await SleepAsync();
            Wake();
        }
        finally {
            Interlocked.Increment(ref _callsCounter);
        }
    }
    
    public void Complete()
    {
        _semaphore.Release();
    }

    private bool CompareNumberOfRequests()
    {
        return _callsCounter < MAX_CALLS;
    }

    private bool WaitInQueueIfNeeded()
    {
        lock (_lockObject) {
            if (_isWait) {
                Monitor.Wait(_lockObject, _interval);
                return true;
            }
        }
        
        return false;
    }

    private async Task SleepAsync()
    {
        _isWait = true;
        
        if (_interval >= TimeSpan.Zero) {
            Console.WriteLine($"Stop {_interval.ToString()}");
            await Task.Delay(_interval);
        }
    }

    private void Wake()
    {
        lock (_lockObject) {
            _isWait = false;
            _callsCounter = 0;
            Monitor.PulseAll(_lockObject);
        }
    }
}