using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.GetUpdates;

public class GetUpdatesRequest : BaseRequest
{
    protected override string MethodName => "getUpdates";
    protected override HttpMethod Method => HttpMethod.Post;
        
    public GetUpdatesRequest(string baseUrl, BaseParameters parameter) 
        : base(baseUrl, null, parameter)
    {
    }
}