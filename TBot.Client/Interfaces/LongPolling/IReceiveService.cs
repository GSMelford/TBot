namespace TBot.Client.Interfaces.LongPolling;

public interface IReceiveService
{
    void StartGettingUpdate();
    void StopGettingUpdate();
}