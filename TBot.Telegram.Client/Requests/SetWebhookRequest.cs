using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class SetWebhookRequest : BaseRequest
{
    protected override string Endpoint => "setWebhook";
    protected override HttpMethod Method => HttpMethod.Get;
    
    public SetWebhookRequest(string baseUrl, BaseParameters? parameters = null) 
        : base(baseUrl, parameters: parameters)
    {
    }
}