using TBot.Client.RequestArchitecture;
using TBot.Client.RequestArchitecture.Structure;

namespace TBot.Client.Domain.Parameters.Webhook;

public class DeleteWebhookParameters : BaseParameters
{
    [Parameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
}