namespace TBot.Client.Domain.Telegram;

public class InputMediaVideo
{
	public string Type { get; set; }
	public string Media { get; set; }
	public string? Thumbnail { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public int? Width { get; set; }
	public int? Height { get; set; }
	public int? Duration { get; set; }
	public bool? SupportsStreaming { get; set; }
	public bool? HasSpoiler { get; set; }

	public InputMediaVideo(
		string type,
		string media,
		string? thumbnail,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		int? width,
		int? height,
		int? duration,
		bool? supportsStreaming,
		bool? hasSpoiler)
	{
		Type = type;
		Media = media;
		Thumbnail = thumbnail;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		Width = width;
		Height = height;
		Duration = duration;
		SupportsStreaming = supportsStreaming;
		HasSpoiler = hasSpoiler;
	}
}