namespace TBot.Client.Domain.Telegram;

public class BotShortDescription
{
	public string ShortDescription { get; set; }

	public BotShortDescription(string shortDescription)
	{
		ShortDescription = shortDescription;
	}
}