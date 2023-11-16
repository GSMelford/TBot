namespace TBot.Client.Domain.Telegram;

public class MenuButtonCommands
{
	public string Type { get; set; }

	public MenuButtonCommands(string type)
	{
		Type = type;
	}
}