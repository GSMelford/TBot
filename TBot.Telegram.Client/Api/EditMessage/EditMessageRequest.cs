using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.EditMessage;

public class EditMessageRequest : BaseRequest
{
    protected override string MethodName => "editMessageText";
    protected override HttpMethod Method => HttpMethod.Get;
        
    public EditMessageRequest(string baseUrl, BaseParameters? parameters = null) 
        : base(baseUrl, null, parameters)
    {
    }
}