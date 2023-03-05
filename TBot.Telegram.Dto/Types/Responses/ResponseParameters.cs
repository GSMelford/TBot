using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types.Responses;

public class ResponseParameters
{
    [JsonPropertyName("migrate_to_chat_id")]
    public int? MigrateToChatId { get; set; }
    
    [JsonPropertyName("retry_after")]
    public int? RetryAfter { get; set; }
}