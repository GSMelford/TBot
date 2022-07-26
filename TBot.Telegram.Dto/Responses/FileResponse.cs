using Newtonsoft.Json;

namespace TBot.Telegram.Dto.Responses;

public class FileResponse
{
    [JsonProperty("ok")] 
    public string? Ok { get; set; }
        
    [JsonProperty("result")] 
    public TelegramFile? Result { get; set; }
}