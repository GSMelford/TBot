using Newtonsoft.Json;

namespace TBot.Telegram.Dto.Types;

public class UserDto
{
    [JsonProperty("id", Required = Required.Always)]
    public int Id { get; set; }
    
    [JsonProperty("is_bot")]
    public int IsBot { get; set; }

    [JsonProperty("first_name", Required = Required.Always)] 
    public string FirstName { get; set; } = null!;
    
    [JsonProperty("last_name")]
    public string? LastName { get; set; }
    
    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("language_code")] 
    public string? LanguageCode { get; set; }
    
    [JsonProperty("is_premium")]
    public bool IsPremium { get; set; }
    
    [JsonProperty("added_to_attachment_menu")]
    public bool AddedToAttachmentMenu { get; set; }
    
    [JsonProperty("can_join_groups")]
    public bool CanJoinGroups { get; set; }
    
    [JsonProperty("can_read_all_group_messages")]
    public bool CanReadAllGroupMessages { get; set; }
    
    [JsonProperty("supports_inline_queries")]
    public bool SupportsInlineQueries { get; set; }
}