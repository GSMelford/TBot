using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto;

public class User
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
        
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
        
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
        
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}