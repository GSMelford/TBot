using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class DeleteWebhookRequest : BaseRequest
{
    protected override string Endpoint => "deleteWebhook";
    protected override HttpMethod Method => HttpMethod.Get;
    
    public DeleteWebhookRequest(string baseUrl, BaseParameters? parameters = null) 
        : base(baseUrl, parameters: parameters)
    {
    }
}