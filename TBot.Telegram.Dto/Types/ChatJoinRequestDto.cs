using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// Represents a join request sent to a chat.
/// </summary>
public class ChatJoinRequestDto
{
	/// <summary>
	/// Chat to which the request was sent
	/// </summary>
	[JsonPropertyName("chat")]
	public ChatDto Chat { get; set; } = null!;

	/// <summary>
	/// User that sent the join request
	/// </summary>
	[JsonPropertyName("from")]
	public UserDto From { get; set; } = null!;

	/// <summary>
	/// Identifier of a private chat with the user who sent the join request. This number may have more than 32 significant bits and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a 64-bit integer or double-precision float type are safe for storing this identifier. The bot can use this identifier for 24 hours to send messages until the join request is processed, assuming no other administrator contacted the user.
	/// </summary>
	[JsonPropertyName("user_chat_id")]
	public int UserChatId { get; set; }

	/// <summary>
	/// Date the request was sent in Unix time
	/// </summary>
	[JsonPropertyName("date")]
	public int Date { get; set; }

	/// <summary>
	/// Optional. Bio of the user.
	/// </summary>
	[JsonPropertyName("bio")]
	public string? Bio { get; set; }

	/// <summary>
	/// Optional. Chat invite link that was used by the user to send the join request
	/// </summary>
	[JsonPropertyName("invite_link")]
	public ChatInviteLinkDto? InviteLink { get; set; }
}