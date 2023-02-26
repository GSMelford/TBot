namespace TBot.Core.RequestLimiter;

public class LimiterContext
{
    public int CallCounter { get; set; }
    public int MaxCalls { get; init; }
    public TimeSpan Interval { get; init; }
    private const long BUFFER_SECOND_TIME = 1;
    public List<Call> Calls { get; set; } = new ();

    public void AddCall()
    {
        Calls.Add(new Call
        {
            Number = CallCounter++,
            Time = GetUtcNowUnixTimeSeconds()
        });
    }

    public void ClearCalls()
    {
        Calls.Clear();
    }

    public bool HasNext()
    {
        return GetFreshCalls(GetUtcNowUnixTimeSeconds()).Count < MaxCalls;
    }

    public TimeSpan GetWaitInterval()
    {
        long utcNow = GetUtcNowUnixTimeSeconds();
        long? firstCallTime = GetFreshCalls(utcNow).FirstOrDefault()?.Time;
        
        if (!firstCallTime.HasValue)
        {
            return TimeSpan.Zero;
        }
        
        TimeSpan firstCallInterval = TimeSpan.FromSeconds(utcNow - firstCallTime.Value);
        TimeSpan waitInterval = Interval.Add(TimeSpan.FromSeconds(BUFFER_SECOND_TIME)) - firstCallInterval;
        return waitInterval.TotalSeconds < 0 ? TimeSpan.Zero : waitInterval;
    }

    private List<Call> GetFreshCalls(long utcNow)
    {
        long callInterval = utcNow - (int)Interval.TotalSeconds;
        return Calls.Where(x => x.Time >= callInterval).OrderBy(x=>x.Time).ToList();
    }

    private static long GetUtcNowUnixTimeSeconds()
    {
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
}

public class Call
{
    public int Number { get; set; }
    public long Time { get; set; }
}