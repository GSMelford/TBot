using Newtonsoft.Json;

namespace TBot.Telegram.Dto.Types.Responses;

public class ResponseParameters
{
    [JsonProperty("migrate_to_chat_id")]
    public int? MigrateToChatId { get; set; }
    
    [JsonProperty("retry_after")]
    public int? RetryAfter { get; set; }
}