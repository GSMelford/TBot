namespace TBot.Client.Domain.Telegram;

public class InlineKeyboardMarkup
{
	public List<InlineKeyboardButton> InlineKeyboard { get; set; }

	public InlineKeyboardMarkup(List<InlineKeyboardButton> inlineKeyboard)
	{
		InlineKeyboard = inlineKeyboard;
	}
}