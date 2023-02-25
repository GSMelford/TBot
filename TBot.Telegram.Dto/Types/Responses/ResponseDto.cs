using Newtonsoft.Json;

namespace TBot.Telegram.Dto.Types.Responses;

public class ResponseDto<TResult>
{
    [JsonProperty("ok")]
    public bool StatusOk { get; set; }
    
    [JsonProperty("result")]
    public TResult? Result { get; set; }
    
    [JsonProperty("description")]
    public string? Description { get; set; }
    
    [JsonProperty("error_code")]
    public int? ErrorCode { get; set; }
    
    [JsonProperty("parameters")]
    public ResponseParameters? ResponseParameters { get; set; }
}