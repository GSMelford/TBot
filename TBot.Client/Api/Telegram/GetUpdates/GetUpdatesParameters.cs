using TBot.Core.Attributes;
using TBot.Core.Parameters;

namespace TBot.Client.Api.Telegram.GetUpdates;

public class GetUpdatesParameters : SerializeParameters
{
    [ParameterName("offset")]
    public int Offset { get; set; }
        
    [ParameterName("limit")]
    public int Limit { get; set; }
        
    [ParameterName("timeout")]
    public int Timeout { get; set; }
}