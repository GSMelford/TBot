using TBot.Core;
using TBot.Core.Parameters;

namespace TBot.Client.Api.Telegram.DeleteMessage;

public class DeleteMessageRequest : Request
{
    protected override string MethodName => "deleteMessage";
    protected override HttpMethod Method => HttpMethod.Post;
        
    public DeleteMessageRequest(string baseUrl, SerializeParameters? parameters = null) 
        : base(baseUrl, null, parameters)
    {
    }
}