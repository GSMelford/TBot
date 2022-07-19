using TBot.Core;
using TBot.Core.Parameters;

namespace TBot.Client.Api.Telegram.SendMessage;

public class SendMessageRequest : Request
{
    protected override string MethodName => "sendMessage";
    protected override HttpMethod Method => HttpMethod.Post;

    public SendMessageRequest(string baseUrl, SerializeParameters parameters) 
        : base(baseUrl, null, parameters)
    {
    }
}