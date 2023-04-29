using TBot.Client.Parameters.Webhook;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests.Webhook;

public class DeleteWebhookRequest : BaseRequest
{
    public DeleteWebhookRequest(DeleteWebhookParameters deleteWebhookParameters)
        : base("/deleteWebhook", HttpMethod.Post, deleteWebhookParameters)
    {
    }
}