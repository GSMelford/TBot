using Newtonsoft.Json;

namespace TBot.Telegram.Dto;

public class TelegramFile
{
    [JsonProperty("file_id")]
    public string? FileId { get; set; }
        
    [JsonProperty("file_unique_id")]
    public string? FileUniqueId { get; set; }
        
    [JsonProperty("file_size")]
    public string? FileSize { get; set; }
        
    [JsonProperty("file_path")]
    public string? FilePath { get; set; }
}