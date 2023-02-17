using TBot.Core;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.Telegram.GetUpdates;

public class GetUpdatesBaseRequest : BaseRequest
{
    protected override string MethodName => "getUpdates";
    protected override HttpMethod Method => HttpMethod.Post;
        
    public GetUpdatesBaseRequest(string baseUrl, BaseParameters parameter) 
        : base(baseUrl, null, parameter)
    {
    }
}