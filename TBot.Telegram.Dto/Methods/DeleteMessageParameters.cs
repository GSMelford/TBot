using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;
using TBot.Telegram.Dto.Types;

namespace TBot.Telegram.Dto.Methods;

public class DeleteMessageParameters : BaseParameters
{
    [Parameter("chat_id", Required = true)]
    public ChatIdentifier ChatId { get; set; } = null!;
    
    [Parameter("message_id", Required = true)]
    public int MessageId { get; set; }
}