namespace TBot.Core.RequestLimiter.Interfaces;

public interface ICallLimiterService
{
    Task WaitAsync(string key, TBotLimiterOptions botLimiterOptions);
}