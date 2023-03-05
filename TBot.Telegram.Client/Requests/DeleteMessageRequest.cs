using TBot.Client.Parameters;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class DeleteMessageRequest : BaseRequest
{
    public DeleteMessageRequest(DeleteMessageParameters deleteMessageParameters)
        : base("/deleteMessage", HttpMethod.Post, deleteMessageParameters)
    {
    }
}