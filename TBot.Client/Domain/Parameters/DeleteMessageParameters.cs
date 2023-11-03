using TBot.Client.RequestArchitecture;
using TBot.Client.RequestArchitecture.Structure;
using TBot.Telegram.Dto.Types;

namespace TBot.Client.Parameters;

public class DeleteMessageParameters : BaseParameters
{
    [Parameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = null!;
    
    [Parameter("message_id", Required = true)]
    public int MessageId { get; set; }
}