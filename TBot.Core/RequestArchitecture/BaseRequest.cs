using TBot.Core.RequestArchitecture.Structure;
using TBot.Core.Utilities;

namespace TBot.Core.RequestArchitecture;

public class BaseRequest
{
    private string BaseUrl { get; }
    private List<Header>? Headers { get; }
    private List<Parameter>? Parameters { get; }
    protected virtual string Endpoint { get; } = null!;
    protected virtual HttpMethod Method { get; } = null!;

    public BaseRequest(string baseUrl, Request request)
    {
        BaseUrl = baseUrl;
        Endpoint = request.Endpoint;
        Method = request.Method;
        Parameters = request.Parameters;
        Headers = request.Headers;
    }
    
    protected BaseRequest(string baseUrl, List<Header>? headers = null, BaseParameters? parameters = null)
    {
        BaseUrl = baseUrl;
        Headers = headers;
        Parameters = parameters?.ToParameters()?.ToList();
    }

    public virtual HttpRequestMessage Build()
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
        UriBuilder uriBuilder = new UriBuilder(BaseUrl + Endpoint);
        
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