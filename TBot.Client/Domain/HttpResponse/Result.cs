using TBot.Client.Utilities;
using TBot.Telegram.Dto.Responses;

namespace TBot.Client.Domain.HttpResponse;

public class Result<TResponseDto> where TResponseDto : new()
{
    public ResponseDto<TResponseDto> Response { get; private set; }
    public HttpResponseMessage HttpResponseMessage { get; private set; }
    
    private Result(ResponseDto<TResponseDto> response, HttpResponseMessage httpResponseMessage)
    {
        Response = response;
        HttpResponseMessage = httpResponseMessage;
    }

    public static async Task<Result<TResponseDto>> CreateAsync(HttpResponseMessage httpResponseMessage)
    {
        var responseStream = await httpResponseMessage.Content.ReadAsStreamAsync();
        var value = await responseStream.DeserializeAsync<ResponseDto<TResponseDto>>();

        return value is not null 
            ? new Result<TResponseDto>(value, httpResponseMessage)
            : new Result<TResponseDto>(new ResponseDto<TResponseDto>(), httpResponseMessage);
    }
}