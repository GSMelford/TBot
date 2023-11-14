using TBot.Telegram.Dto.Updates;

namespace TBot.Client.Domain.LongPolling;

public interface ILongPollingService
{
    void Start(Func<UpdateDto, Task> updateAction, CancellationToken? cancellationToken = null);
}