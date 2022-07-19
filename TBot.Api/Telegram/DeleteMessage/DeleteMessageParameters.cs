using TBot.Core.Attributes;
using TBot.Core.Parameters;
using Telegram.Dto;

namespace TBot.Api.Telegram.DeleteMessage;

public class DeleteMessageParameters : SerializeParameters
{
    [ParameterName("chat_id", true)] 
    public ChatId ChatId { get; set; }
        
    [ParameterName("message_id", true)] 
    public int MessageId { get; set; }
}