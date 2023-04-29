using TBot.Client.Parameters.Webhook;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests.Webhook;

public class SetWebhookRequest : BaseRequest
{
    public SetWebhookRequest(SetWebhookParameters setWebhookParameters)
        : base("/setWebhook", HttpMethod.Post, setWebhookParameters)
    {
    }
}