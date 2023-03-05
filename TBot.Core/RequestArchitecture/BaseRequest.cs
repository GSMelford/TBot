using TBot.Core.RequestArchitecture.Structure;
using TBot.Core.Utilities;

namespace TBot.Core.RequestArchitecture;

public class BaseRequest
{
    protected virtual string Endpoint { get; set; } = null!;
    protected virtual HttpMethod Method { get; set; } = null!;
    public List<Header>? Headers { get; set; }
    public List<Parameter>? Parameters { get; set; }

    public BaseRequest(BaseParameters baseParameters, List<Header>? headers = null)
    {
        Headers = headers;
        Parameters = baseParameters.ToParameters()?.ToList();
    }
    
    public HttpRequestMessage Build(string baseUrl)
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
        UriBuilder uriBuilder = new UriBuilder(baseUrl + Endpoint);
        
        if (Headers?.Count > 0) {
            foreach (Header parameter in Headers.OrEmptyIfNull())
            {
                httpRequestMessage.Headers.TryAddWithoutValidation(parameter.Key, parameter.Value);
            }
        }
        
        if (Parameters is not null) {
            uriBuilder.Query = string.Join("&", Parameters.Select(x => $"{x.Key}={x.Value}"));
        }

        httpRequestMessage.RequestUri = new Uri(uriBuilder.Uri.AbsoluteUri);
        httpRequestMessage.Method = Method;
        
        return httpRequestMessage;
    }
}