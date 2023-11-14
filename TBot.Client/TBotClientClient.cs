using Microsoft.Extensions.Options;
using TBot.Client.Domain.CallLimiter;
using TBot.Client.Domain.HttpRequests;
using TBot.Client.Domain.HttpResponse;
using TBot.Client.Domain.Parameters;
using TBot.Client.Domain.TBot;
using TBot.Client.Services.CallLimiter;
using TBot.Telegram.Dto.Types;
using TBot.Telegram.Dto.Updates;

namespace TBot.Client;

public class TBotClientClient : ITBotClient
{
    private readonly ITBotRequestService _tBotRequestService;
    private readonly ICallLimiterService? _callLimitService;

    private readonly Options.TBotOptions _botOptions;
    private readonly CallLimiterOptions? _limitConfig;

    public TBotClientClient(
        IOptions<Options.TBotOptions> botOptions,
        ITBotRequestService tBotRequestService, 
        IOptions<CallLimiterOptions>? limitConfig = null,
        ICallLimiterService? callLimitService = null)
    {
        _botOptions = botOptions.Value;
        _limitConfig = limitConfig?.Value;
        _tBotRequestService = tBotRequestService;
        _callLimitService = callLimitService;
    }
    
    public Task<Result<MessageDto>> SendMessageAsync(SendMessageParameters parameters)
    {
        return SendAsync<MessageDto>(
            RequestDescriptor.Create(HttpMethod.Post, "/sendMessage", parameters.ToParameters().ToList()));
    }

    public Task<Result<List<UpdateDto>>> GetUpdateAsync(GetUpdateParameters parameters)
    {
        return SendAsync<List<UpdateDto>>(
            RequestDescriptor.Create(HttpMethod.Post, "/getUpdates", parameters.ToParameters().ToList()));
    }
    
    private async Task<Result<TResponse>> SendAsync<TResponse>(RequestDescriptor request) where TResponse : new()
    {
        var response = await SendAsync(request);
        return await Result<TResponse>.CreateAsync(response);
    }
    
    public async Task<HttpResponseMessage> SendAsync(RequestDescriptor request)
    {
        var telegramRequest = TelegramRequest.Create(_botOptions.Token, request);
        
        if (_callLimitService is not null && !string.IsNullOrEmpty(telegramRequest.ChatId)) {
            await _callLimitService.WaitAsync(telegramRequest.ChatId, _limitConfig!); 
        }

        return await _tBotRequestService.SendAsync(telegramRequest.Build());
    }
}