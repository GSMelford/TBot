namespace TBot.Core.RequestLimiter;

public class LimitConfig
{
    public int ThreadInitialCount { get; set; }
    public int ThreadMaxCount { get; set; }
    public int MaxCalls { get; set; }
    public TimeSpan CallsInterval { get; set; }
    public TimeSpan ThreadTimeout { get; set; }
    public TimeSpan StoreTimeout { get; set; }

    public void Validate(int maxCalls, TimeSpan interval)
    {
        if (MaxCalls > maxCalls)
        {
            throw new Exception($"The maximum number of requests for this bot {maxCalls}");
        }
        
        if (CallsInterval > interval)
        {
            throw new Exception($"The maximum interval of requests for this bot {interval}");
        }
    }
}