using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types.Responses;

public class ResponseDto<TResult>
{
    [JsonPropertyName("ok")]
    public bool StatusOk { get; set; }
    
    [JsonPropertyName("result")]
    public TResult? Result { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; }
    
    [JsonPropertyName("parameters")]
    public ResponseParameters? ResponseParameters { get; set; }
}