using System.Collections.Generic;
using Newtonsoft.Json;

namespace TBot.Telegram.Dto.Responses;

public class UpdateResponse
{
    [JsonProperty("ok")] 
    public string? Ok { get; set; }
        
    [JsonProperty("result")] 
    public List<Update>? Result { get; set; }
}