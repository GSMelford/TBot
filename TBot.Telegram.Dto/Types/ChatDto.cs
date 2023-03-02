using Newtonsoft.Json;

namespace TBot.Telegram.Dto.Types;

public class ChatDto
{
    [JsonProperty("id", Required = Required.Always)]
    public int Id { get; set; }

    [JsonProperty("type", Required = Required.Always)] 
    public string Type { get; set; } = null!;
    
    [JsonProperty("title")]
    public string? Title { get; set; }
    
    [JsonProperty("username")]
    public string? Username { get; set; }
    
    [JsonProperty("first_name")]
    public string? FirstName { get; set; }
    
    [JsonProperty("last_name")]
    public string? LastName { get; set; }
    
    [JsonProperty("is_forum")]
    public string? IsForum { get; set; }
    
    [JsonProperty("photo")]
    public ChatPhotoDto? Photo { get; set; }
    
    [JsonProperty("active_usernames")]
    public string[]? ActiveUsernames { get; set; }
    
    [JsonProperty("emoji_status_custom_emoji_id")]
    public string? EmojiStatusCustomEmojiId { get; set; }
    
    [JsonProperty("bio")]
    public string? Bio { get; set; }
    
    [JsonProperty("has_private_forwards")]
    public bool? HasPrivateForwards { get; set; }
    
    [JsonProperty("has_restricted_voice_and_video_messages")]
    public bool? HasRestrictedVoiceAndVideoMessages { get; set; }
    
    [JsonProperty("join_to_send_messages")]
    public bool? JoinToSendMessages { get; set; }
    
    [JsonProperty("join_by_request")]
    public bool? JoinByRequest { get; set; }
    
    [JsonProperty("description")]
    public string? Description { get; set; }
    
    [JsonProperty("invite_link")]
    public string? InviteLink { get; set; }
    
    [JsonProperty("pinned_message")]
    public MessageDto? PinnedMessage { get; set; }
    
    [JsonProperty("permissions")]
    public ChatPermissionsDto? Permissions { get; set; }
    
    [JsonProperty("slow_mode_delay")]
    public int? SlowModeDelay { get; set; }
    
    [JsonProperty("message_auto_delete_time")]
    public int? MessageAutoDeleteTime { get; set; }
    
    [JsonProperty("has_aggressive_anti_spam_enabled")]
    public bool? HasAggressiveAntiSpamEnabled { get; set; }
    
    [JsonProperty("has_hidden_members")]
    public bool? HasHiddenMembers { get; set; }
    
    [JsonProperty("has_protected_content")]
    public bool? HasProtectedContent { get; set; }
    
    [JsonProperty("sticker_set_name")]
    public string? StickerSetName { get; set; }
    
    [JsonProperty("can_set_sticker_set")]
    public bool? CanSetStickerSet { get; set; }
    
    [JsonProperty("linked_chat_id")]
    public int? LinkedChatId { get; set; }
    
    [JsonProperty("location")]
    public ChatLocationDto? Location { get; set; }
}