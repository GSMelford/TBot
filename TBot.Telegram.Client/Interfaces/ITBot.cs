using TBot.Core.RequestArchitecture;
using TBot.Core.RequestLimiter;

namespace TBot.Client.Interfaces;

public interface ITBot
{
    void Init(BotSettings? botSettings = null, LimiterConfig? limitConfig = null);
    Task<HttpResponseMessage> PostAsync(BaseRequest request);
    Task<HttpResponseMessage> PostWithLimiterAsync(BaseRequest request, string limiterKey);
}