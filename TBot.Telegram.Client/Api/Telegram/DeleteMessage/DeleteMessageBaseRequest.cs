using TBot.Core;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.Telegram.DeleteMessage;

public class DeleteMessageBaseRequest : BaseRequest
{
    protected override string MethodName => "deleteMessage";
    protected override HttpMethod Method => HttpMethod.Post;
        
    public DeleteMessageBaseRequest(string baseUrl, BaseParameters? parameters = null) 
        : base(baseUrl, null, parameters)
    {
    }
}