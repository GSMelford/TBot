using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;
using TBot.Telegram.Dto;
using TBot.Telegram.Dto.SendMessage;
using TBot.Telegram.Dto.SendMessage.ReplyMarkup.Abstracts;

namespace TBot.Client.Api.SendMessage;

public class SendMessageParameters : BaseParameters
{
    [Parameter("chat_id", true)]
    public ChatId ChatId { get; set; }
        
    [Parameter("text", true)]
    public string Text { get; set; }
        
    [Parameter("parseMode")]
    public ParseMode ParseMode { get; set; }
        
    [Parameter("disable_web_page_preview")]
    public bool DisableWebPagePreview { get; set; }
        
    [Parameter("disable_notification")]
    public bool DisableNotification { get; set; }
        
    [Parameter("reply_to_message_id")]
    public int ReplyToMessageId { get; set; }
        
    [Parameter("reply_markup")]
    public ReplyMarkup ReplyMarkup { get; set; }
}