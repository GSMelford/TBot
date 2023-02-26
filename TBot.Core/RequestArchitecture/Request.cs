using TBot.Core.RequestArchitecture.Structure;

namespace TBot.Core.RequestArchitecture;

public class Request
{
    public string Endpoint { get; set; } = null!;
    public HttpMethod Method { get; set; } = null!;
    public List<Header>? Headers { get; set; }
    public List<Parameter>? Parameters { get; set; }
}