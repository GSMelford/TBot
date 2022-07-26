using Newtonsoft.Json;

namespace TBot.Telegram.Dto;

public class Chat
{
    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("type")]
    public ChatType Type { get; set; }
    
    [JsonProperty("title")]
    public string? Title { get; set; }
    
    [JsonProperty("username")]
    public string? Username { get; set; }
    
    [JsonProperty("first_name")]
    public string? FirstName { get; set; }
    
    [JsonProperty("last_name")]
    public string? LastName { get; set; }
    
    [JsonProperty("all_members_are_administrators")]
    public bool? AllMembersAreAdministrators { get; set; }
}

public enum ChatType
{
    [JsonProperty("private")]
    Private,
    [JsonProperty("private")]
    Group,
    [JsonProperty("supergroup")]
    Supergroup,
    [JsonProperty("channel")]
    Channel,
}