using Microsoft.AspNetCore.Mvc;

namespace TBot.Telegram.Dto.UpdateModule;

public class Message
{
    [BindProperty(Name = "message_id")]
    public int MessageId { get; set; }
    
    [BindProperty(Name = "from")]
    public User? From { get; set; }
    
    [BindProperty(Name = "date")]
    public int Date { get; set; }
    
    [BindProperty(Name = "chat")]
    public Chat Chat { get; set; } = null!;
    
    [BindProperty(Name = "forward_from")]
    public User? ForwardFromUser { get; set; }
    
    [BindProperty(Name = "forward_date")]
    public int? ForwardDate { get; set; }
    
    [BindProperty(Name = "migrate_to_chat_id")]
    public int? MigrateToChatId { get; set; }
    
    [BindProperty(Name = "migrate_from_chat_id")]
    public int? MigrateFromChatId { get; set; }
    
    [BindProperty(Name = "text")]
    public string? Text { get; set; }
    
    [BindProperty(Name = "caption")]
    public string? Caption { get; set; }
    
    [BindProperty(Name = "new_chat_title")]
    public string? NewChatTitle { get; set; }
    
    [BindProperty(Name = "delete_chat_photo")]
    public bool? DeleteChatPhoto { get; set; }
    
    [BindProperty(Name = "group_chat_created")]
    public bool? GroupChatCreated { get; set; }
    
    [BindProperty(Name = "supergroup_chat_created")]
    public bool? SupergroupChatCreated { get; set; }
    
    [BindProperty(Name = "channel_chat_created")]
    public bool? ChannelChatCreated { get; set; }
    
    [BindProperty(Name = "new_chat_member")]
    public User? NewChatMember { get; set; }
    
    [BindProperty(Name = "left_chat_member")]
    public User? LeftChatMember { get; set; }
    
    [BindProperty(Name = "pinned_message")]
    public Message? PinnedMessage { get; set; }
    
    [BindProperty(Name = "reply_to_message")]
    public Message? ReplyToMessage { get; set; }
    
    [BindProperty(Name = "audio")]
    public Audio? Audio { get; set; }
    
    [BindProperty(Name = "document")]
    public Document? Document { get; set; }
    
    [BindProperty(Name = "sticker")]
    public Sticker? Sticker { get; set; }
    
    [BindProperty(Name = "video")]
    public Video? Video { get; set; }
    
    [BindProperty(Name = "voice")]
    public Voice? Voice { get; set; }
    
    [BindProperty(Name = "contact")]
    public Contact? Contact { get; set; }
    
    [BindProperty(Name = "location")]
    public Location? Location { get; set; }
    
    [BindProperty(Name = "venue")]
    public Venue? Venue { get; set; }
    
    [BindProperty(Name = "entities")]
    public List<MessageEntity>? Entities { get; set; }
    
    [BindProperty(Name = "new_chat_photo")]
    public List<PhotoSize>? NewChatPhoto { get; set; }
    
    [BindProperty(Name = "photo")]
    public List<Photo>? Photos { get; set; }
}