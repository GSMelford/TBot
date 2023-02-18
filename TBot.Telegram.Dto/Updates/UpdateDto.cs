using Newtonsoft.Json;
using TBot.Telegram.Dto.InlineModes;
using TBot.Telegram.Dto.Payments;
using TBot.Telegram.Dto.Types;

namespace TBot.Telegram.Dto.Updates;

public class UpdateDto
{
    [JsonProperty("update_id", Required = Required.Always)]
    public int UpdateId { get; set; }
    
    [JsonProperty("message")]
    public MessageDto? Message { get; set; }
    
    [JsonProperty("edited_message")]
    public MessageDto? EditedMessage { get; set; }
    
    [JsonProperty("channel_post")]
    public MessageDto? ChannelPost { get; set; }
    
    [JsonProperty("inline_query")]
    public InlineQueryDto? InlineQuery { get; set; }
    
    [JsonProperty("edited_channel_post")]
    public MessageDto? EditedChannelPost { get; set; }
    
    [JsonProperty("chosen_inline_result")]
    public ChosenInlineResultDto? ChosenInlineResult { get; set; }
    
    [JsonProperty("callback_query")]
    public CallbackQueryDto? CallbackQuery { get; set; }
    
    [JsonProperty("shipping_query")]
    public ShippingQueryDto? ShippingQuery { get; set; }
    
    [JsonProperty("pre_checkout_query")]
    public PreCheckoutQueryDto? PreCheckoutQuery { get; set; }
    
    [JsonProperty("poll")]
    public PollDto? Poll { get; set; }
    
    [JsonProperty("poll_answer")]
    public PollAnswerDto? PollAnswer { get; set; }
    
    [JsonProperty("my_chat_member")]
    public ChatMemberUpdatedDto? MyChatMember { get; set; }
    
    [JsonProperty("chat_member")]
    public ChatMemberUpdatedDto? ChatMember { get; set; }
    
    [JsonProperty("chat_join_request")]
    public ChatJoinRequestDto? ChatJoinRequest { get; set; }
}