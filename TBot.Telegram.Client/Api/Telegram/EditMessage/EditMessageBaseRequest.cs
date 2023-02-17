using TBot.Core;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.Telegram.EditMessage;

public class EditMessageBaseRequest : BaseRequest
{
    protected override string MethodName => "editMessageText";
    protected override HttpMethod Method => HttpMethod.Get;
        
    public EditMessageBaseRequest(string baseUrl, BaseParameters? parameters = null) 
        : base(baseUrl, null, parameters)
    {
    }
}