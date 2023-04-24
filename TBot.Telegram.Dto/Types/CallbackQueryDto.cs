using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

public class CallbackQueryDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("from")]
    public UserDto From { get; set; } = null!;
    
    [JsonPropertyName("message")]
    public MessageDto? Message { get; set; }
    
    [JsonPropertyName("inline_message_id")]
    public string? InlineMessageId { get; set; }
    
    [JsonPropertyName("chat_instance")]
    public string ChatInstance { get; set; } = null!;
    
    [JsonPropertyName("data")]
    public string? Data { get; set; }
    
    [JsonPropertyName("game_short_name")]
    public string? GameShortName { get; set; }
}