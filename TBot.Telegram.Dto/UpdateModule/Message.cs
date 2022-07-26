using System.Collections.Generic;
using Newtonsoft.Json;

namespace TBot.Telegram.Dto.UpdateModule;

public class Message
{
    [JsonProperty("message_id")]
    public int MessageId { get; set; }
    
    [JsonProperty("from")]
    public User? From { get; set; }
    
    [JsonProperty("date")]
    public int Date { get; set; }

    [JsonProperty("chat")] 
    public Chat Chat { get; set; } = null!;
    
    [JsonProperty("forward_from")]
    public User? ForwardFromUser { get; set; }
    
    [JsonProperty("forward_date")]
    public int? ForwardDate { get; set; }
    
    [JsonProperty("migrate_to_chat_id")]
    public int? MigrateToChatId { get; set; }
    
    [JsonProperty("migrate_from_chat_id")]
    public int? MigrateFromChatId { get; set; }
    
    [JsonProperty("text")]
    public string? Text { get; set; }
    
    [JsonProperty("caption")]
    public string? Caption { get; set; }
    
    [JsonProperty("new_chat_title")]
    public string? NewChatTitle { get; set; }
    
    [JsonProperty("delete_chat_photo")]
    public bool? DeleteChatPhoto { get; set; }
    
    [JsonProperty("group_chat_created")]
    public bool? GroupChatCreated { get; set; }
    
    [JsonProperty("supergroup_chat_created")]
    public bool? SupergroupChatCreated { get; set; }
    
    [JsonProperty("channel_chat_created")]
    public bool? ChannelChatCreated { get; set; }
    
    [JsonProperty("new_chat_member")]
    public User? NewChatMember { get; set; }
    
    [JsonProperty("left_chat_member")]
    public User? LeftChatMember { get; set; }
    
    [JsonProperty("pinned_message")]
    public Message? PinnedMessage { get; set; }
    
    [JsonProperty("reply_to_message")]
    public Message? ReplyToMessage { get; set; }
    
    [JsonProperty("audio")]
    public Audio? Audio { get; set; }
    
    [JsonProperty("document")]
    public Document? Document { get; set; }
    
    [JsonProperty("sticker")]
    public Sticker? Sticker { get; set; }
    
    [JsonProperty("video")]
    public Video? Video { get; set; }
    
    [JsonProperty("voice")]
    public Voice? Voice { get; set; }
    
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
    
    [JsonProperty("location")]
    public Location? Location { get; set; }
    
    [JsonProperty("venue")]
    public Venue? Venue { get; set; }
    
    [JsonProperty("entities")]
    public List<MessageEntity>? Entities { get; set; }
    
    [JsonProperty("new_chat_photo")]
    public List<PhotoSize>? NewChatPhoto { get; set; }
    
    [JsonProperty("photo")]
    public List<Photo>? Photos { get; set; }
}