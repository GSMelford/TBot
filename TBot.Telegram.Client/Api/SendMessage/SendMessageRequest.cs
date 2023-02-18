using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.SendMessage;

public class SendMessageRequest : BaseRequest
{
    protected override string MethodName => "sendMessage";
    protected override HttpMethod Method => HttpMethod.Post;

    public SendMessageRequest(string baseUrl, BaseParameters parameter) 
        : base(baseUrl, null, parameter)
    {
    }
}