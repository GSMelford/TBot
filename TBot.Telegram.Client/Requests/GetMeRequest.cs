using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests;

public class GetMeRequest : BaseRequest
{
    public GetMeRequest()
        : base("/getMe", HttpMethod.Get)
    {
    } 
}