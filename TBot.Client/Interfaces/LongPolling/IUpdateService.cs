using TBot.Telegram.Dto.Updates;

namespace TBot.Client.Interfaces.LongPolling;

public interface IUpdateService
{
    public Task UpdateAsync(UpdateDto updateDto);
}