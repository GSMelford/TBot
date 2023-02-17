using TBot.Core.Attributes;
using TBot.Core.RequestArchitecture;
using TBot.Telegram.Dto;

namespace TBot.Client.Api.Telegram.SendVideo;

public class SendVideoParameter : BaseParameters
{
    [Parameter("chat_id", true)]
    public ChatId ChatId { get; set; }
        
    [Parameter("video", true)]
    public VideoFile Video { get; set; }
        
    [Parameter("caption")]
    public string Caption { get; set; }
}