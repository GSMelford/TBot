using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.DeleteMessage;

public class DeleteMessageRequest : BaseRequest
{
    protected override string MethodName => "deleteMessage";
    protected override HttpMethod Method => HttpMethod.Post;
        
    public DeleteMessageRequest(string baseUrl, BaseParameters? parameters = null) 
        : base(baseUrl, null, parameters)
    {
    }
}