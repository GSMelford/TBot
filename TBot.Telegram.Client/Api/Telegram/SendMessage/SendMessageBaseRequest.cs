using TBot.Core;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.Telegram.SendMessage;

public class SendMessageBaseRequest : BaseRequest
{
    protected override string MethodName => "sendMessage";
    protected override HttpMethod Method => HttpMethod.Post;

    public SendMessageBaseRequest(string baseUrl, BaseParameters parameter) 
        : base(baseUrl, null, parameter)
    {
    }
}