using TBot.Client.Parameters.Stickers;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Requests.Stickers;

public class SendStickerRequest : BaseRequest
{
    public SendStickerRequest(SendStickersParameters sendStickersParameters)
        : base("/sendSticker", HttpMethod.Post, sendStickersParameters)
    {
    }
}