using TBot.Telegram.Dto.Types;

namespace TBot.Client.Domain.Telegram;

public class BotCommandScopeChatMember
{
	public string Type { get; set; }
	public ChatIdentifier ChatId { get; set; }
	public int UserId { get; set; }

	public BotCommandScopeChatMember(string type, ChatIdentifier chatId, int userId)
	{
		Type = type;
		ChatId = chatId;
		UserId = userId;
	}
}