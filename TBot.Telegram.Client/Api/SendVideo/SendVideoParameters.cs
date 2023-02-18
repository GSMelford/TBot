using TBot.Core.RequestArchitecture;
using TBot.Core.RequestArchitecture.Structure;
using TBot.Telegram.Dto;

namespace TBot.Client.Api.SendVideo;

public class SendVideoParameters : BaseParameters
{
    [Parameter("chat_id", true)]
    public ChatId ChatId { get; set; }
        
    [Parameter("video", true)]
    public VideoFile Video { get; set; }
        
    [Parameter("caption")]
    public string Caption { get; set; }
}