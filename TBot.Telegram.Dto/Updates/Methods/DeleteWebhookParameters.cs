using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;

namespace TBot.Telegram.Dto.Updates.Methods;

public class DeleteWebhookParameters : BaseParameters
{
    [Parameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
}