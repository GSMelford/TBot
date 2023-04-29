using TBot.Core.RequestLimiter;

namespace TBot.Client;

public class BotBuilder
{
    public BotSettings BotSettings { get; private set; } = null!;
    public LimitConfig LimiterConfig = new ()
    {
        CallsInterval = TimeSpan.FromSeconds(60),
        MaxCalls = 20,
        StoreTimeout = TimeSpan.FromSeconds(2),
        ThreadTimeout = TimeSpan.FromSeconds(30),
        ThreadInitialCount = 20,
        ThreadMaxCount = 20
    };
    
    public LimitStore? LimitStore { get; set; }
    
    public string? RedisConnectionString { get; private set; }
    
    public BotBuilder AddBotSettings(BotSettings botSettings)
    {
        botSettings.Validate();
        BotSettings = botSettings;
        return this;
    }

    public BotBuilder AddRedisConfig(string connectionString)
    {
        LimitStore = Core.RequestLimiter.LimitStore.Redis;
        RedisConnectionString = connectionString;
        return this;
    }
    
    public BotBuilder AddLimitConfig(LimitConfig? limitConfig = null)
    {
        if (limitConfig is not null)
        {
            LimiterConfig = limitConfig;
        }
        
        LimiterConfig.Validate(20, TimeSpan.FromSeconds(60));
        return this;
    }
}