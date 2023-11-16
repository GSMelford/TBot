namespace TBot.Client.Domain.Telegram;

public class MessageId
{
	public int MessageIdValue { get; set; }

	public MessageId(int messageIdValue)
	{
		MessageIdValue = messageIdValue;
	}
}