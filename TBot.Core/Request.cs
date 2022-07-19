using TBot.Core.Interfaces;
using TBot.Core.Parameters;

namespace TBot.Core;

public abstract class Request : IExecutable
{
    protected string BaseUrl { get; }
    protected abstract string MethodName { get; }
    protected abstract HttpMethod Method { get; }
    protected List<Parameter>? Headers { get; }
    protected SerializeParameters? SerializeParameters { get; }

    protected Request(string baseUrl, List<Parameter>? headers = null, SerializeParameters? parameters = null)
    {
        BaseUrl = baseUrl;
        Headers = headers;
        SerializeParameters = parameters;
    }
    
    public async Task<HttpResponseMessage> Execute(HttpClient httpClient)
    {
        return await httpClient.SendAsync(BuildRequest());
    }
    
    protected virtual HttpRequestMessage BuildRequest()
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
        UriBuilder uriBuilder = new UriBuilder(BaseUrl + MethodName);
        
        if (Headers?.Count > 0) {
            foreach (Parameter parameter in Headers.OrEmptyIfNull())
            {
                httpRequestMessage.Headers.TryAddWithoutValidation(parameter.Key, parameter.Value?.ToString());
            }
        }
        
        IEnumerable<Parameter>? parameters = SerializeParameters?.BuildParameters();
        if (parameters is not null) {
            uriBuilder.Query = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
        }

        httpRequestMessage.RequestUri = new Uri(uriBuilder.Uri.AbsoluteUri);
        httpRequestMessage.Method = Method;
        
        return httpRequestMessage;
    }
}