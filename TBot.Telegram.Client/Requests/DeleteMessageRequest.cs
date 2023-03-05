using TBot.Client.Parameters;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class DeleteMessageRequest : BaseRequest
{
    protected override string Endpoint => "/deleteMessage";
    protected override HttpMethod Method => HttpMethod.Post;
        
    public DeleteMessageRequest(DeleteMessageParameters deleteMessageParameters) : base(deleteMessageParameters)
    {
    }
}