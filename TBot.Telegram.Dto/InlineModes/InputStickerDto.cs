using System.Collections.Generic;
using System.Text.Json.Serialization;
using TBot.Telegram.Dto.Stikers;
using TBot.Telegram.Dto.Types;

namespace TBot.Telegram.Dto.InlineModes;

/// <summary>
/// This object describes a sticker to be added to a sticker set.
/// </summary>
public class InputStickerDto
{
	/// <summary>
	/// The added sticker. Pass a file_id as a String to send a file that already exists on the Telegram servers, pass an HTTP URL as a String for Telegram to get a file from the Internet, upload a new one using multipart/form-data, or pass “attach://<file_attach_name>” to upload a new one using multipart/form-data under <file_attach_name> name. Animated and video stickers can't be uploaded via HTTP URL. More information on Sending Files »
	/// </summary>
	[JsonPropertyName("sticker")]
	public InputFile Sticker { get; set; } = null!;

	/// <summary>
	/// List of 1-20 emoji associated with the sticker
	/// </summary>
	[JsonPropertyName("emoji_list")]
	public List<string> EmojiList { get; set; } = null!;

	/// <summary>
	/// Optional. Position where the mask should be placed on faces. For “mask” stickers only.
	/// </summary>
	[JsonPropertyName("mask_position")]
	public MaskPositionDto? MaskPosition { get; set; }

	/// <summary>
	/// Optional. List of 0-20 search keywords for the sticker with total length of up to 64 characters. For “regular” and “custom_emoji” stickers only.
	/// </summary>
	[JsonPropertyName("keywords")]
	public List<string>? Keywords { get; set; }
}