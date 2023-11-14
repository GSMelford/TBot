using TBot.Client.Domain.Parameters.Structure;

namespace TBot.Client.Domain.Parameters.Webhook;

public class DeleteWebhookParameters : BaseParameters
{
    [Parameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
}