using Newtonsoft.Json;

namespace TBot.Telegram.Dto.UpdateModule;

public class CallbackQuery
{
    [JsonProperty("id")]
    public string? Id { get; set; }
        
    [JsonProperty("from")]
    public User? FromUser { get; set; }
        
    [JsonProperty("message")]
    public Message? Message { get; set; }
        
    [JsonProperty("inline_message_id")]
    public string? InlineMessageId { get; set; }
        
    [JsonProperty("data")]
    public string? Data { get; set; }
}