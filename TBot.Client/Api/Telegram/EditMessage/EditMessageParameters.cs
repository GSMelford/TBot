using TBot.Core.Attributes;
using TBot.Core.Parameters;
using TBot.Telegram.Dto;

namespace TBot.Client.Api.Telegram.EditMessage;

public class EditMessageParameters : SerializeParameters
{
    [ParameterName("chat_id", true)] 
    public ChatId ChatId { get; set; }
        
    [ParameterName("text", true)] 
    public string Text { get; set; }
        
    [ParameterName("message_id", true)] 
    public int MessageId { get; set; }
        
    [ParameterName("disable_web_page_preview")]
    public bool DisableWebPagePreview { get; set; }
}