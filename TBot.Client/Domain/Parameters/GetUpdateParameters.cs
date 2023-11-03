using TBot.Client.RequestArchitecture;
using TBot.Client.RequestArchitecture.Structure;

namespace TBot.Client.Domain.Parameters;

public class GetUpdateParameters : BaseParameters
{
    [Parameter("offset")]
    public int Offset { get; set; }
    
    [Parameter("limit")]
    public int Limit { get; set; }
    
    [Parameter("timeout")]
    public int Timeout { get; set; }

    [Parameter("allowed_updates")] 
    public List<string> AllowedUpdates { get; set; } = new ();
}