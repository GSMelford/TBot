﻿using TBot.Core.Attributes;
using TBot.Core.Parameters;
using TBot.Telegram.Dto;

namespace TBot.Client.Api.Telegram.SendVideo;

public class SendVideoParameters : SerializeParameters
{
    [ParameterName("chat_id", true)]
    public ChatId ChatId { get; set; }
        
    [ParameterName("video", true)]
    public VideoFile Video { get; set; }
        
    [ParameterName("caption")]
    public string Caption { get; set; }
}