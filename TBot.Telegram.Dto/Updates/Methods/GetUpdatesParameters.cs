using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;

namespace TBot.Telegram.Dto.Updates.Methods;

public class GetUpdatesParameters : BaseParameters
{
    [Parameter("offset")]
    public int Offset { get; set; }
        
    [Parameter("limit")]
    public int Limit { get; set; }
        
    [Parameter("timeout")]
    public int Timeout { get; set; }
}