namespace TBot.Client.Domain.Telegram;

public class BotDescription
{
	public string Description { get; set; }

	public BotDescription(string description)
	{
		Description = description;
	}
}