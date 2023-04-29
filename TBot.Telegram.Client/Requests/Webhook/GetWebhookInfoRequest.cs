using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests.Webhook;

public class GetWebhookInfoRequest : BaseRequest
{
    public GetWebhookInfoRequest()
        : base("/getWebhookInfo", HttpMethod.Post)
    {
    }
}