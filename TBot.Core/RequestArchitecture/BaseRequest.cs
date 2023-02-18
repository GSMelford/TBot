using TBot.Core.RequestArchitecture.Structure;
using TBot.Core.Utilities;

namespace TBot.Core.RequestArchitecture;

public abstract class BaseRequest
{
    protected string BaseUrl { get; }
    protected abstract string MethodName { get; }
    protected abstract HttpMethod Method { get; }
    protected List<Parameter>? Headers { get; }
    protected BaseParameters? SerializeParameter { get; }

    protected BaseRequest(string baseUrl, List<Parameter>? headers = null, BaseParameters? parameter = null)
    {
        BaseUrl = baseUrl;
        Headers = headers;
        SerializeParameter = parameter;
    }

    public virtual HttpRequestMessage ToHttpRequestMessage()
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
        UriBuilder uriBuilder = new UriBuilder(BaseUrl + MethodName);
        
        if (Headers?.Count > 0) {
            foreach (Parameter parameter in Headers.OrEmptyIfNull())
            {
                httpRequestMessage.Headers.TryAddWithoutValidation(parameter.Key, parameter.Value?.ToString());
            }
        }
        
        IEnumerable<Parameter>? parameters = SerializeParameter?.ToList();
        if (parameters is not null) {
            uriBuilder.Query = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
        }

        httpRequestMessage.RequestUri = new Uri(uriBuilder.Uri.AbsoluteUri);
        httpRequestMessage.Method = Method;
        
        return httpRequestMessage;
    }
}