using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;

namespace TBot.Telegram.Dto.Updates.Methods;

public class SetWebhookParameters : BaseParameters
{
    [Parameter("url", Required = true)]
    public string Url { get; set; } = null!;
    
    //TODO: Develop a special type for sending files. Watch here => https://core.telegram.org/bots/api#inputfile
    /*[JsonProperty("certificate")]
    public string Certificate { get; set; } = null!;*/
    
    [Parameter("ip_address")]
    public string IpAddress { get; set; } = null!;
    
    [Parameter("max_connections")]
    public int MaxConnections { get; set; }
    
    [Parameter("allowed_updates")]
    public string[] AllowedUpdates { get; set; } = null!;
    
    [Parameter("drop_pending_updates")]
    public bool DropPendingUpdates { get; set; }
    
    [Parameter("secret_token")]
    public string SecretToken { get; set; } = null!;
}