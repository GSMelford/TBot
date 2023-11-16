namespace TBot.Client.Domain.Telegram;

public class VideoChatScheduled
{
	public int StartDate { get; set; }

	public VideoChatScheduled(int startDate)
	{
		StartDate = startDate;
	}
}