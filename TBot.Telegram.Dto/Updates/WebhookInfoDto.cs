using Newtonsoft.Json;

namespace TBot.Telegram.Dto.Updates;

public class WebhookInfoDto
{
    [JsonProperty("url", Required = Required.Always)]
    public string Url { get; set; } = null!;
    
    [JsonProperty("has_custom_certificate", Required = Required.Always)]
    public bool HasCustomCertificate { get; set; }
    
    [JsonProperty("pending_update_count", Required = Required.Always)]
    public int PendingUpdateCount { get; set; }
    
    [JsonProperty("ip_address")]
    public string? IpAddress { get; set; }
    
    [JsonProperty("last_error_date")]
    public int LastErrorDate { get; set; }
    
    [JsonProperty("last_error_message")]
    public string? LastErrorMessage { get; set; }
    
    [JsonProperty("last_synchronization_error_date")]
    public int LastSynchronizationErrorDate { get; set; }
    
    [JsonProperty("max_connections")]
    public int MaxConnections { get; set; }
    
    [JsonProperty("allowed_updates")]
    public string[]? AllowedUpdates { get; set; }
}