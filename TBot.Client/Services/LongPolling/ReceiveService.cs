using TBot.Client.Domain.Parameters;
using TBot.Client.Interfaces;
using TBot.Client.Interfaces.LongPolling;

namespace TBot.Client.Services.LongPolling;

public class ReceiveService : IReceiveService
{
    private readonly ITelegramBot _bot;
    private readonly GetUpdateParameters _updateParameters;
    private readonly IUpdateService _updateService;

    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly CancellationToken _cancellationToken;

    public ReceiveService(
        ITelegramBot bot,
        IUpdateService updateService,
        CancellationTokenSource? cancellationTokenSource = null, 
        UpdateOptions? updateOptions = null)
    {
        _bot = bot;
        _updateService = updateService;
        _updateParameters = new GetUpdateParameters
        {
            Limit = updateOptions?.Limit ?? Constants.Update.Limit,
            Timeout = updateOptions?.TimeoutSeconds ?? Constants.Update.Timeout
        };

        _cancellationTokenSource = cancellationTokenSource ?? new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
    }
    
    public void StartGettingUpdate()
    {
        Task.Factory.StartNew(async () =>
        {
            while (true)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                var result = await _bot.GetUpdateAsync(_updateParameters);
                if (!result.Response.Result!.Any())
                {
                    continue;
                }

                foreach (var updateDto in result.Response.Result!)
                {
                    await _updateService.UpdateAsync(updateDto);
                    _updateParameters.Offset = updateDto.UpdateId + 1;
                }
            }
        }, _cancellationToken);
    }

    public void StopGettingUpdate()
    {
        _cancellationTokenSource.Cancel();
    }
}