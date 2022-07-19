using TBot.Core;
using TBot.Core.Parameters;

namespace TBot.Client.Api.Telegram.EditMessage;

public class EditMessageRequest : Request
{
    protected override string MethodName => "editMessageText";
    protected override HttpMethod Method => HttpMethod.Get;
        
    public EditMessageRequest(string baseUrl, SerializeParameters? parameters = null) 
        : base(baseUrl, null, parameters)
    {
    }
}