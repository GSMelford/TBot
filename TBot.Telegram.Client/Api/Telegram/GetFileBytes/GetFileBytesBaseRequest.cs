using TBot.Core;
using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;

namespace TBot.Client.Api.Telegram.GetFileBytes;

public class GetFileBytesBaseRequest : BaseRequest
{
    protected override string MethodName => "";
    protected override HttpMethod Method => HttpMethod.Get;
        
    public GetFileBytesBaseRequest(
        string baseUrl, 
        string telegramFilePath, 
        List<Parameter>? headers = null, 
        BaseParameters? parameters = null) : base(baseUrl, headers, parameters)
    {
    }
}