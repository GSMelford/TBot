using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class GetUpdatesRequest : BaseRequest
{
    protected override string Endpoint => "getUpdates";
    protected override HttpMethod Method => HttpMethod.Post;
        
    public GetUpdatesRequest(string baseUrl, BaseParameters parameters) 
        : base(baseUrl, null, parameters)
    {
    }
}