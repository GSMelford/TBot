using TBot.Client.Parameters;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class DeleteMessageRequest : BaseRequest
{
    public override string Endpoint => "/deleteMessage";
    public override HttpMethod Method => HttpMethod.Post;
        
    public DeleteMessageRequest(DeleteMessageParameters deleteMessageParameters) : base(deleteMessageParameters)
    {
    }
}