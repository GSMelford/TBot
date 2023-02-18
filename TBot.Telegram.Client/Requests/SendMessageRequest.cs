using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class SendMessageRequest : BaseRequest
{
    protected override string Endpoint => "sendMessage";
    protected override HttpMethod Method => HttpMethod.Post;

    public SendMessageRequest(string baseUrl, BaseParameters parameters) 
        : base(baseUrl, null, parameters)
    {
    }
}