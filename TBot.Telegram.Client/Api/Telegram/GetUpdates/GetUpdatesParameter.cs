using TBot.Core.Attributes;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.Telegram.GetUpdates;

public class GetUpdatesParameter : BaseParameters
{
    [Parameter("offset")]
    public int Offset { get; set; }
        
    [Parameter("limit")]
    public int Limit { get; set; }
        
    [Parameter("timeout")]
    public int Timeout { get; set; }
}