using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;
using TBot.Telegram.Dto;

namespace TBot.Client.Api.DeleteMessage;

public class DeleteMessageParameters : BaseParameters
{
    [Parameter("chat_id", true)] 
    public ChatId ChatId { get; set; }
        
    [Parameter("message_id", true)] 
    public int MessageId { get; set; }
}