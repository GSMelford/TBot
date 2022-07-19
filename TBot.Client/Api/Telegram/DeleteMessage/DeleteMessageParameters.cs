using TBot.Core.Attributes;
using TBot.Core.Parameters;
using TBot.Telegram.Dto;

namespace TBot.Client.Api.Telegram.DeleteMessage;

public class DeleteMessageParameters : SerializeParameters
{
    [ParameterName("chat_id", true)] 
    public ChatId ChatId { get; set; }
        
    [ParameterName("message_id", true)] 
    public int MessageId { get; set; }
}