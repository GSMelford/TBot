using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.UpdateModule;

public class Message
{
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }
    
    [JsonPropertyName("from")]
    public User? From { get; set; }
    
    [JsonPropertyName("date")]
    public int Date { get; set; }

    [JsonPropertyName("chat")] 
    public Chat Chat { get; set; } = null!;
    
    [JsonPropertyName("forward_from")]
    public User? ForwardFromUser { get; set; }
    
    [JsonPropertyName("forward_date")]
    public int? ForwardDate { get; set; }
    
    [JsonPropertyName("migrate_to_chat_id")]
    public int? MigrateToChatId { get; set; }
    
    [JsonPropertyName("migrate_from_chat_id")]
    public int? MigrateFromChatId { get; set; }
    
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    
    [JsonPropertyName("caption")]
    public string? Caption { get; set; }
    
    [JsonPropertyName("new_chat_title")]
    public string? NewChatTitle { get; set; }
    
    [JsonPropertyName("delete_chat_photo")]
    public bool? DeleteChatPhoto { get; set; }
    
    [JsonPropertyName("group_chat_created")]
    public bool? GroupChatCreated { get; set; }
    
    [JsonPropertyName("supergroup_chat_created")]
    public bool? SupergroupChatCreated { get; set; }
    
    [JsonPropertyName("channel_chat_created")]
    public bool? ChannelChatCreated { get; set; }
    
    [JsonPropertyName("new_chat_member")]
    public User? NewChatMember { get; set; }
    
    [JsonPropertyName("left_chat_member")]
    public User? LeftChatMember { get; set; }
    
    [JsonPropertyName("pinned_message")]
    public Message? PinnedMessage { get; set; }
    
    [JsonPropertyName("reply_to_message")]
    public Message? ReplyToMessage { get; set; }
    
    [JsonPropertyName("audio")]
    public Audio? Audio { get; set; }
    
    [JsonPropertyName("document")]
    public Document? Document { get; set; }
    
    [JsonPropertyName("sticker")]
    public Sticker? Sticker { get; set; }
    
    [JsonPropertyName("video")]
    public Video? Video { get; set; }
    
    [JsonPropertyName("voice")]
    public Voice? Voice { get; set; }
    
    [JsonPropertyName("contact")]
    public Contact? Contact { get; set; }
    
    [JsonPropertyName("location")]
    public Location? Location { get; set; }
    
    [JsonPropertyName("venue")]
    public Venue? Venue { get; set; }
    
    [JsonPropertyName("entities")]
    public List<MessageEntity>? Entities { get; set; }
    
    [JsonPropertyName("new_chat_photo")]
    public List<PhotoSize>? NewChatPhoto { get; set; }
    
    [JsonPropertyName("photo")]
    public List<Photo>? Photos { get; set; }
}