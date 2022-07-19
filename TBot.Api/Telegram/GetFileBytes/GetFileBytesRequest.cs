using TBot.Core;
using TBot.Core.Parameters;

namespace TBot.Api.Telegram.GetFileBytes;

public class GetFileBytesRequest : Request
{
    protected override string MethodName => "";
    protected override HttpMethod Method => HttpMethod.Get;
        
    public GetFileBytesRequest(
        string baseUrl, 
        string telegramFilePath, 
        List<Parameter>? headers = null, 
        SerializeParameters? parameters = null) : base(baseUrl, headers, parameters)
    {
    }
}