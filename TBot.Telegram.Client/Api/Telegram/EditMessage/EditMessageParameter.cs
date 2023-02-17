using TBot.Core.Attributes;
using TBot.Core.RequestArchitecture;
using TBot.Telegram.Dto;

namespace TBot.Client.Api.Telegram.EditMessage;

public class EditMessageParameter : BaseParameters
{
    [Parameter("chat_id", true)] 
    public ChatId ChatId { get; set; }
        
    [Parameter("text", true)] 
    public string Text { get; set; }
        
    [Parameter("message_id", true)] 
    public int MessageId { get; set; }
        
    [Parameter("disable_web_page_preview")]
    public bool DisableWebPagePreview { get; set; }
}