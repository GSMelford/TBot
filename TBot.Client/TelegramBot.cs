using System.Diagnostics.CodeAnalysis;
using TBot.Client.Domain.HttpRequests;
using TBot.Client.Domain.HttpResponse;
using TBot.Client.Interfaces;
using TBot.Client.Parameters;
using TBot.Client.Parameters.Stickers;
using TBot.Client.RequestArchitecture.Interfaces;
using TBot.Client.RequestLimiter;
using TBot.Client.RequestLimiter.Interfaces;
using TBot.Telegram.Dto.Responses;
using TBot.Telegram.Dto.Types;

namespace TBot.Client;

public class TelegramBot : ITBot
{
    private readonly ITBotRequestService _tBotRequestService;
    private readonly ICallLimiterService? _callLimitService;

    private readonly TBotOptions _botOptions;
    private readonly TBotLimiterOptions? _limitConfig;

    public TelegramBot(
        ITBotRequestService tBotRequestService, 
        TBotOptions botOptions, 
        TBotLimiterOptions? limitConfig = null,
        ICallLimiterService? callLimitService = null)
    {
        _tBotRequestService = tBotRequestService;
        _botOptions = botOptions;
        _limitConfig = limitConfig;
        _callLimitService = callLimitService;
    }
    
    public Task<Result<MessageDto>> SendMessageAsync(SendMessageParameters parameters)
    {
        return SendAsync<MessageDto>(
            RequestDescriptor.Create(HttpMethod.Post, "/sendMessage", parameters.ToParameters().ToList()));
    }
    
    private async Task<Result<TResponse>> SendAsync<TResponse>(RequestDescriptor request) where TResponse : new()
    {
        var response = await SendAsync(request);
        return await Result<TResponse>.CreateAsync(response);
    }
    
    public async Task<HttpResponseMessage> SendAsync(RequestDescriptor request)
    {
        var telegramRequest = TelegramRequest.Create(_botOptions.BotToken, request);
        
        if (_callLimitService is not null) {
            await _callLimitService.WaitAsync(telegramRequest.ChatId, _limitConfig!); 
        }

        return await _tBotRequestService.SendAsync(telegramRequest.Build());
    }
}