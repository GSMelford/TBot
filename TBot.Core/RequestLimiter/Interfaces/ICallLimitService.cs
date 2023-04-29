namespace TBot.Core.RequestLimiter.Interfaces;

public interface ICallLimitService
{
    Task WaitAsync(string key);
}