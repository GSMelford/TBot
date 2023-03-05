using TBot.Client.Parameters;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class SendMessageRequest : BaseRequest
{
    public SendMessageRequest(SendMessageParameters sendMessageParameters)
        : base("/sendMessage", HttpMethod.Post, sendMessageParameters)
    {
    }
}