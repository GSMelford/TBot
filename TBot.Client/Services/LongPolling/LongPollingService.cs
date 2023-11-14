using Microsoft.Extensions.Options;
using TBot.Client.Domain.LongPolling;
using TBot.Client.Domain.Parameters;
using TBot.Client.Domain.TBot;
using TBot.Client.Options;
using TBot.Telegram.Dto.Updates;

namespace TBot.Client.Services.LongPolling;

public class LongPollingService : ILongPollingService
{
    private readonly ITBotClient _botClient;
    private GetUpdateParameters UpdateParameters { get; set; } = new ();

    public LongPollingService(ITBotClient botClient, IOptions<UpdateOptions>? updateOptions = null)
    {
        _botClient = botClient;
        if (updateOptions is null) {
            return;
        }
        
        UpdateParameters.Limit = updateOptions.Value.Limit;
        UpdateParameters.Timeout = updateOptions.Value.TimeoutSeconds;
    }
    
    public void Start(Func<UpdateDto, Task> updateAction, CancellationToken? cancellationToken = null)
    {
        Task.Factory.StartNew(async () =>
        {
            while (true)
            {
                if (cancellationToken?.IsCancellationRequested == true)
                {
                    return;
                }

                var result = await _botClient.GetUpdateAsync(UpdateParameters);
                if (!result.Response.Result!.Any())
                {
                    continue;
                }

                foreach (var updateDto in result.Response.Result!)
                {
                    await updateAction(updateDto);
                    UpdateParameters.Offset = updateDto.UpdateId + 1;
                }
            }
        });
    }
}