namespace TBot.Client.RequestLimiter.Interfaces;

public interface ICallLimiterService
{
    Task WaitAsync(string key, TBotLimiterOptions botLimiterOptions);
}