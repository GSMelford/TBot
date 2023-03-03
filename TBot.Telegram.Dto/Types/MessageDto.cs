using Newtonsoft.Json;

namespace TBot.Telegram.Dto.Types;

public class MessageDto
{
    [JsonProperty("message_id", Required = Required.Always)]
    public int MessageId { get; set; }
    
    [JsonProperty("message_thread_id")]
    public int? MessageThreadId { get; set; }
    
    [JsonProperty("from")]
    public UserDto? From { get; set; }
    
    [JsonProperty("sender_chat")]
    public ChatDto? SenderChat { get; set; }
    
    [JsonProperty("date")]
    public int Date { get; set; }

    [JsonProperty("chat", Required = Required.Always)] 
    public ChatDto Chat { get; set; } = null!;
    
    [JsonProperty("forward_from")]
    public UserDto? ForwardFrom { get; set; }
    
    [JsonProperty("forward_from_chat")]
    public ChatDto? ForwardFromChat { get; set; }
    
    [JsonProperty("forward_from_message_id")]
    public int? ForwardFromMessageId { get; set; }
    
    [JsonProperty("forward_signature")]
    public string? ForwardSignature { get; set; }
    
    [JsonProperty("forward_sender_name")]
    public string? ForwardSenderName { get; set; }
    
    [JsonProperty("forward_date")]
    public int? ForwardDate { get; set; }
    
    [JsonProperty("is_topic_message")]
    public bool? IsTopicMessage { get; set; }
    
    [JsonProperty("is_automatic_forward")]
    public bool? IsAutomaticForward { get; set; }
    
    [JsonProperty("reply_to_message")]
    public MessageDto? ReplyToMessage { get; set; }
    
    [JsonProperty("via_bot")]
    public UserDto? ViaBot { get; set; }
    
    [JsonProperty("edit_date")]
    public int? EditDate { get; set; }
    
    [JsonProperty("has_protected_content")]
    public bool? HasProtectedContent { get; set; }
    
    [JsonProperty("media_group_id")]
    public string? MediaGroupId { get; set; }
    
    [JsonProperty("author_signature")]
    public string? AuthorSignature { get; set; }
    
    [JsonProperty("text")]
    public string? Text { get; set; }
    
    [JsonProperty("entities")]
    public List<MessageEntityDto>? Entities { get; set; }
    
    [JsonProperty("animation")]
    public AnimationDto? Animation { get; set; }
    
    [JsonProperty("audio")]
    public AudioDto? Audio { get; set; }
    
    [JsonProperty("document")]
    public DocumentDto? Document { get; set; }
    
    [JsonProperty("photo")]
    public PhotoSizeDto[]? Photo { get; set; }
    
    [JsonProperty("sticker")]
    public StickerDto? Sticker { get; set; }
    
    [JsonProperty("video")]
    public VideoDto? Video { get; set; }
    
    [JsonProperty("video_note")]
    public VideoNoteDto? VideoNote { get; set; }
    
    [JsonProperty("voice")]
    public VoiceDto? Voice { get; set; }
    
    [JsonProperty("caption")]
    public string? Caption { get; set; }
    
    [JsonProperty("caption_entities")]
    public MessageEntityDto[]? CaptionEntities { get; set; }
    
    [JsonProperty("has_media_spoiler")]
    public bool? HasMediaSpoiler { get; set; }
    
    [JsonProperty("contact")]
    public ContactDto? Contact { get; set; }
    
    [JsonProperty("dice")]
    public DiceDto? Dice { get; set; }
    
    [JsonProperty("game")]
    public GameDto? Game { get; set; }
    
    [JsonProperty("poll")]
    public PollDto? Poll { get; set; }
    
    [JsonProperty("venue")]
    public VenueDto? Venue { get; set; }
    
    [JsonProperty("location")]
    public LocationDto? Location { get; set; }
    
    [JsonProperty("new_chat_members")]
    public UserDto[]? NewChatMembers { get; set; }
    
    [JsonProperty("left_chat_member")]
    public UserDto? LeftChatMember { get; set; }
    
    [JsonProperty("new_chat_title")]
    public string? NewChatTitle { get; set; }
    
    [JsonProperty("new_chat_photo")]
    public PhotoSizeDto[]? NewChatPhoto { get; set; }
    
    [JsonProperty("delete_chat_photo")]
    public bool? DeleteChatPhoto { get; set; }
    
    [JsonProperty("group_chat_created")]
    public bool? GroupChatCreated { get; set; }
    
    [JsonProperty("supergroup_chat_created")]
    public bool? SupergroupChatCreated { get; set; }
    
    [JsonProperty("channel_chat_created")]
    public bool? ChannelChatCreated { get; set; }
    
    [JsonProperty("message_auto_delete_timer_changed")]
    public MessageAutoDeleteTimerChangedDto? MessageAutoDeleteTimerChanged { get; set; }
    
    [JsonProperty("migrate_to_chat_id")]
    public int? MigrateToChatId { get; set; }
    
    [JsonProperty("migrate_from_chat_id")]
    public int? MigrateFromChatId { get; set; }
    
    [JsonProperty("pinned_message")]
    public MessageDto? PinnedMessage { get; set; }
    
    [JsonProperty("invoice")]
    public InvoiceDto? Invoice { get; set; }
    
    [JsonProperty("successful_payment")]
    public SuccessfulPaymentDto? SuccessfulPayment { get; set; }
    
    [JsonProperty("user_shared")]
    public UserSharedDto? UserShared { get; set; }
    
    [JsonProperty("chat_shared")]
    public ChatSharedDto? ChatShared { get; set; }
    
    [JsonProperty("connected_website")]
    public string? ConnectedWebsite { get; set; }
    
    [JsonProperty("write_access_allowed")]
    public WriteAccessAllowedDto? WriteAccessAllowed { get; set; }
    
    [JsonProperty("passport_data")]
    public PassportDataDto? PassportData { get; set; }
    
    [JsonProperty("proximity_alert_triggered")]
    public ProximityAlertTriggeredDto? ProximityAlertTriggered { get; set; }
    
    [JsonProperty("forum_topic_created")]
    public ForumTopicCreatedDto? ForumTopicCreated { get; set; }
    
    [JsonProperty("forum_topic_edited")]
    public ForumTopicEditedDto? ForumTopicEdited { get; set; }
    
    [JsonProperty("forum_topic_closed")]
    public ForumTopicClosedDto? ForumTopicClosed { get; set; }
    
    [JsonProperty("forum_topic_reopened")]
    public ForumTopicReopenedDto? ForumTopicReopened { get; set; }
    
    [JsonProperty("general_forum_topic_hidden")]
    public GeneralForumTopicHiddenDto? GeneralForumTopicHidden { get; set; }
    
    [JsonProperty("general_forum_topic_unhidden")]
    public GeneralForumTopicUnhiddenDto? GeneralForumTopicUnhidden { get; set; }
    
    [JsonProperty("video_chat_scheduled")]
    public VideoChatScheduledDto? VideoChatScheduled { get; set; }
    
    [JsonProperty("video_chat_started")]
    public VideoChatStartedDto? VideoChatStarted { get; set; }
    
    [JsonProperty("video_chat_ended")]
    public VideoChatEndedDto? VideoChatEnded { get; set; }
    
    [JsonProperty("video_chat_participants_invited")]
    public VideoChatParticipantsInvitedDto? VideoChatParticipantsInvited { get; set; }
    
    [JsonProperty("web_app_data")]
    public WebAppDataDto? WebAppData { get; set; }
    
    [JsonProperty("reply_markup")]
    public InlineKeyboardMarkupDto? ReplyMarkup { get; set; }
}