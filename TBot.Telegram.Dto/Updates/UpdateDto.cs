using System.Text.Json.Serialization;
using TBot.Telegram.Dto.InlineModes;
using TBot.Telegram.Dto.Payments;
using TBot.Telegram.Dto.Types;

namespace TBot.Telegram.Dto.Updates;

public class UpdateDto
{
    [JsonPropertyName("update_id")]
    public int UpdateId { get; set; }
    
    [JsonPropertyName("message")]
    public MessageDto? Message { get; set; }
    
    [JsonPropertyName("edited_message")]
    public MessageDto? EditedMessage { get; set; }
    
    [JsonPropertyName("channel_post")]
    public MessageDto? ChannelPost { get; set; }
    
    [JsonPropertyName("inline_query")]
    public InlineQueryDto? InlineQuery { get; set; }
    
    [JsonPropertyName("edited_channel_post")]
    public MessageDto? EditedChannelPost { get; set; }
    
    [JsonPropertyName("chosen_inline_result")]
    public ChosenInlineResultDto? ChosenInlineResult { get; set; }
    
    [JsonPropertyName("callback_query")]
    public CallbackQueryDto? CallbackQuery { get; set; }
    
    [JsonPropertyName("shipping_query")]
    public ShippingQueryDto? ShippingQuery { get; set; }
    
    [JsonPropertyName("pre_checkout_query")]
    public PreCheckoutQueryDto? PreCheckoutQuery { get; set; }
    
    [JsonPropertyName("poll")]
    public PollDto? Poll { get; set; }
    
    [JsonPropertyName("poll_answer")]
    public PollAnswerDto? PollAnswer { get; set; }
    
    [JsonPropertyName("my_chat_member")]
    public ChatMemberUpdatedDto? MyChatMember { get; set; }
    
    [JsonPropertyName("chat_member")]
    public ChatMemberUpdatedDto? ChatMember { get; set; }
    
    [JsonPropertyName("chat_join_request")]
    public ChatJoinRequestDto? ChatJoinRequest { get; set; }
}