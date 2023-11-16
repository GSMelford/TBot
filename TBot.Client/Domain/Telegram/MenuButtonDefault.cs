namespace TBot.Client.Domain.Telegram;

public class MenuButtonDefault
{
	public string Type { get; set; }

	public MenuButtonDefault(string type)
	{
		Type = type;
	}
}