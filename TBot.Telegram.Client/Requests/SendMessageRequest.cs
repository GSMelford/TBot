using TBot.Client.Parameters;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class SendMessageRequest : BaseRequest
{
    public override string Endpoint => "/sendMessage";
    public override HttpMethod Method => HttpMethod.Post;
    
    public SendMessageRequest(SendMessageParameters sendMessageParameters) : base(sendMessageParameters)
    {
    }
}