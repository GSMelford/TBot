using Newtonsoft.Json;

namespace TBot.Telegram.Dto.Types;

public class MessageEntityDto
{
    [JsonProperty("type", Required = Required.Always)]
    public MessageEntityType Type { get; set; } = null!;
    
    [JsonProperty("offset", Required = Required.Always)]
    public int Offset { get; set; }
    
    [JsonProperty("length", Required = Required.Always)]
    public int Length { get; set; }
    
    [JsonProperty("url")]
    public string? Url { get; set; }
    
    [JsonProperty("user")]
    public UserDto? User { get; set; }
    
    [JsonProperty("language")]
    public string? Language { get; set; }
    
    [JsonProperty("custom_emoji_id")]
    public string? CustomEmojiId { get; set; }
}