namespace TBot.Client.Domain.Telegram;

public class SentWebAppMessage
{
	public string? InlineMessageId { get; set; }

	public SentWebAppMessage(string? inlineMessageId)
	{
		InlineMessageId = inlineMessageId;
	}
}