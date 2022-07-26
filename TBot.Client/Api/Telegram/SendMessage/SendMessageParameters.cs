using TBot.Core.Attributes;
using TBot.Core.Parameters;
using TBot.Telegram.Dto;
using TBot.Telegram.Dto.SendMessage;
using TBot.Telegram.Dto.SendMessage.ReplyMarkup.Abstracts;

namespace TBot.Client.Api.Telegram.SendMessage;

public class SendMessageParameters : SerializeParameters
{
    [ParameterName("chat_id", true)]
    public ChatId ChatId { get; set; }
        
    [ParameterName("text", true)]
    public string Text { get; set; }
        
    [ParameterName("parseMode")]
    public ParseMode ParseMode { get; set; }
        
    [ParameterName("disable_web_page_preview")]
    public bool DisableWebPagePreview { get; set; }
        
    [ParameterName("disable_notification")]
    public bool DisableNotification { get; set; }
        
    [ParameterName("reply_to_message_id")]
    public int ReplyToMessageId { get; set; }
        
    [ParameterName("reply_markup")]
    public ReplyMarkup ReplyMarkup { get; set; }
}