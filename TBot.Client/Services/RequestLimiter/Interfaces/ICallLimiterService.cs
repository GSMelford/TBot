namespace TBot.Client.Services.RequestLimiter.Interfaces;

public interface ICallLimiterService
{
    Task WaitAsync(string key, TBotLimiterOptions botLimiterOptions);
}