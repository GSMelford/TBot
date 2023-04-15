using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

public class ContactDto
{
    [JsonPropertyName("phone_number")] 
    public string PhoneNumber { get; set; } = null!;
    
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = null!;
    
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = null!;
    
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    
    [JsonPropertyName("vcard")]
    public string? Vcard { get; set; }
}