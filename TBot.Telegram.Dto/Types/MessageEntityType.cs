namespace TBot.Telegram.Dto.Types;

public class MessageEntityType
{
    private MessageEntityTypeEnum Type { get; set; }
    
    public MessageEntityType(MessageEntityTypeEnum type)
    {
        Type = type;
    }
    
    public static implicit operator MessageEntityType(string value)
    {
        return new MessageEntityType(value switch
        {
            "mention" => MessageEntityTypeEnum.Mention,
            "hashtag" => MessageEntityTypeEnum.Hashtag,
            "cashtag" => MessageEntityTypeEnum.CashTag,
            "bot_command" => MessageEntityTypeEnum.BotCommand,
            "url" => MessageEntityTypeEnum.Url,
            "email" => MessageEntityTypeEnum.Email,
            "phone_number" => MessageEntityTypeEnum.PhoneNumber,
            "bold" => MessageEntityTypeEnum.Bold,
            "italic" => MessageEntityTypeEnum.Italic,
            "underline" => MessageEntityTypeEnum.Underline,
            "strikethrough" => MessageEntityTypeEnum.Strikethrough,
            "spoiler" => MessageEntityTypeEnum.Spoiler,
            "code" => MessageEntityTypeEnum.Code,
            "pre" => MessageEntityTypeEnum.Pre,
            "text_link" => MessageEntityTypeEnum.TextLink,
            "text_mention" => MessageEntityTypeEnum.TextMention,
            "custom_emoji" => MessageEntityTypeEnum.CustomEmoji,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        });
    }
    
    public enum MessageEntityTypeEnum
    {
        Mention,
        Hashtag,
        CashTag,
        BotCommand,
        Url,
        Email,
        PhoneNumber,
        Bold,
        Italic,
        Underline,
        Strikethrough,
        Spoiler,
        Code,
        Pre,
        TextLink,
        TextMention,
        CustomEmoji
    }
}

