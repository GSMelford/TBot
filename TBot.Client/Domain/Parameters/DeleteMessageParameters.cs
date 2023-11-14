using TBot.Client.Domain.Parameters.Structure;
using TBot.Telegram.Dto.Types;

namespace TBot.Client.Domain.Parameters;

public class DeleteMessageParameters : BaseParameters
{
    [Parameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = null!;
    
    [Parameter("message_id", Required = true)]
    public int MessageId { get; set; }
}