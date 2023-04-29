using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;

namespace TBot.Client.Parameters.Webhook;

public class DeleteWebhookParameters : BaseParameters
{
    [Parameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
}