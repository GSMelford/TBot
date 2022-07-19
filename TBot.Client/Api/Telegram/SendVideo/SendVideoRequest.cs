using System.Text;
using TBot.Core;
using TBot.Core.Parameters;

namespace TBot.Client.Api.Telegram.SendVideo;

public class SendVideoRequest : Request
{
    protected override string MethodName => "sendVideo";
    protected override HttpMethod Method => HttpMethod.Post;
        
    public SendVideoRequest(string baseUrl, SerializeParameters parameters) 
        : base(baseUrl, null, parameters)
    {
    }
    
    protected override HttpRequestMessage BuildRequest() 
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
        UriBuilder uriBuilder = new UriBuilder(BaseUrl + MethodName);
        
        if (Headers?.Count > 0) {
            foreach (Parameter parameter in Headers.OrEmptyIfNull())
            {
                httpRequestMessage.Headers.TryAddWithoutValidation(parameter.Key, parameter.Value?.ToString());
            }
        }
        
        MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
        foreach (Parameter parameter in (SerializeParameters?.BuildParameters()).OrEmptyIfNull())
        {
            object? value = parameter.Value;
            if (value is VideoFile videoFile) //TODO Обобщить до типа Stream
            {
                string fileName = videoFile.VideoName ?? "video";
                string contentDisposition = $@"form-data; name=""{"video"}"";filename=""{fileName}""";
                        
                contentDisposition = new string(Encoding.UTF8.GetBytes(contentDisposition).Select(Convert.ToChar).ToArray());
                HttpContent mediaPartContent = new StreamContent(videoFile.VideoStream)
                {
                    Headers = {
                        {"Content-Type", "application/octet-stream"},
                        {"Content-Disposition", contentDisposition}
                    }
                };

                multipartFormDataContent.Add(mediaPartContent, "video", fileName);
            }
            else if (value is not null) {
                multipartFormDataContent.Add(new StringContent(value.ToString()!), parameter.Key);
            }
        }

        httpRequestMessage.Content = multipartFormDataContent;
        httpRequestMessage.RequestUri = new Uri(uriBuilder.Uri.AbsoluteUri);
        httpRequestMessage.Method = Method;
        return httpRequestMessage;
    }
}