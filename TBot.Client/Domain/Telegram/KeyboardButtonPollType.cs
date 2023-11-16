namespace TBot.Client.Domain.Telegram;

public class KeyboardButtonPollType
{
	public string? Type { get; set; }

	public KeyboardButtonPollType(string? type)
	{
		Type = type;
	}
}