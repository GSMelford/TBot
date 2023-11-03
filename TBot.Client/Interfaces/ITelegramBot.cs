using TBot.Client.Domain.HttpRequests;
using TBot.Client.Domain.HttpResponse;
using TBot.Client.Domain.Parameters;
using TBot.Telegram.Dto.Types;
using TBot.Telegram.Dto.Updates;

namespace TBot.Client.Interfaces;

public interface ITelegramBot
{
    Task<Result<MessageDto>> SendMessageAsync(SendMessageParameters parameters);
    Task<Result<List<UpdateDto>>> GetUpdateAsync(GetUpdateParameters parameters);
    Task<HttpResponseMessage> SendAsync(RequestDescriptor request);
}