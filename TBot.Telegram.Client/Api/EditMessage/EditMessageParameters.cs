using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;
using TBot.Telegram.Dto;

namespace TBot.Client.Api.EditMessage;

public class EditMessageParameters : BaseParameters
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