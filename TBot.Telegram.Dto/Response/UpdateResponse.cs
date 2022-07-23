using Newtonsoft.Json;
using TBot.Telegram.Dto.UpdateModule;

namespace TBot.Telegram.Dto.Response;

public class UpdateResponse
{
    [JsonProperty("ok")] 
    public string? Ok { get; set; }
        
    [JsonProperty("result")] 
    public List<Update>? Result { get; set; }
}