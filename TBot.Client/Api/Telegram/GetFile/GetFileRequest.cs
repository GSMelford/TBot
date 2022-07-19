using TBot.Core;
using TBot.Core.Parameters;

namespace TBot.Client.Api.Telegram.GetFile;

public class GetFileRequest : Request
{
    protected override string MethodName => "getFile";
    protected override HttpMethod Method => HttpMethod.Get;
        
    public GetFileRequest(string baseUrl, SerializeParameters? parameters = null) 
        : base(baseUrl, null, parameters)
    {
    }
}