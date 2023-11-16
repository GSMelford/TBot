namespace TBot.Client.Domain.Telegram;

public class MessageAutoDeleteTimerChanged
{
	public int MessageAutoDeleteTime { get; set; }

	public MessageAutoDeleteTimerChanged(int messageAutoDeleteTime)
	{
		MessageAutoDeleteTime = messageAutoDeleteTime;
	}
}