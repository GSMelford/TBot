using TBot.Core;
using TBot.Core.Parameters;

namespace TBot.Api.Telegram.GetUpdates;

public class GetUpdatesRequest : Request
{
    protected override string MethodName => "getUpdates";
    protected override HttpMethod Method => HttpMethod.Post;
        
    public GetUpdatesRequest(string baseUrl, SerializeParameters parameters) 
        : base(baseUrl, null, parameters)
    {
    }
}