namespace TBot.Core.RequestLimiter;

public class LimiterConfig
{
    public int ThreadInitialCount { get; set; }
    public int ThreadMaxCount { get; set; }
    public int MaxCalls { get; set; }
    public TimeSpan CallsInterval { get; set; }
    public TimeSpan ThreadTimeout { get; set; }
    public TimeSpan StoreTimeout { get; set; }
}