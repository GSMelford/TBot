using TBot.Core.RequestArchitecture.Structure;
using TBot.Core.Utilities;

namespace TBot.Core.RequestArchitecture;

public abstract class BaseRequest
{
    protected string BaseUrl { get; }
    protected abstract string Endpoint { get; }
    protected abstract HttpMethod Method { get; }
    protected List<Header>? Headers { get; }
    protected BaseParameters? SerializeParameters { get; }

    protected BaseRequest(string baseUrl, List<Header>? headers = null, BaseParameters? parameters = null)
    {
        BaseUrl = baseUrl;
        Headers = headers;
        SerializeParameters = parameters;
    }

    public virtual HttpRequestMessage ToHttpRequestMessage()
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
        UriBuilder uriBuilder = new UriBuilder(BaseUrl + Endpoint);
        
        if (Headers?.Count > 0) {
            foreach (Header parameter in Headers.OrEmptyIfNull())
            {
                httpRequestMessage.Headers.TryAddWithoutValidation(parameter.Key, parameter.Value?.ToString());
            }
        }
        
        IEnumerable<Parameter>? parameters = SerializeParameters?.ToList();
        if (parameters is not null) {
            uriBuilder.Query = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
        }

        httpRequestMessage.RequestUri = new Uri(uriBuilder.Uri.AbsoluteUri);
        httpRequestMessage.Method = Method;
        
        return httpRequestMessage;
    }
}