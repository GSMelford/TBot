using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto;

public class Chat
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    
    [JsonPropertyName("all_members_are_administrators")]
    public bool? AllMembersAreAdministrators { get; set; }
}