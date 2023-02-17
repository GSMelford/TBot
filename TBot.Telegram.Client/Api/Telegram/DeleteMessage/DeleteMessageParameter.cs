using TBot.Core.Attributes;
using TBot.Core.RequestArchitecture;
using TBot.Telegram.Dto;

namespace TBot.Client.Api.Telegram.DeleteMessage;

public class DeleteMessageParameter : BaseParameters
{
    [Parameter("chat_id", true)] 
    public ChatId ChatId { get; set; }
        
    [Parameter("message_id", true)] 
    public int MessageId { get; set; }
}