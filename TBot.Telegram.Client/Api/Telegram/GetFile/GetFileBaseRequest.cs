using TBot.Core;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.Telegram.GetFile;

public class GetFileBaseRequest : BaseRequest
{
    protected override string MethodName => "getFile";
    protected override HttpMethod Method => HttpMethod.Get;
        
    public GetFileBaseRequest(string baseUrl, BaseParameters? parameters = null) 
        : base(baseUrl, null, parameters)
    {
    }
}