using Newtonsoft.Json;
using TBot.Client.Domain.Parameters.ReplyMarkupParameters.Buttons;

namespace TBot.Client.Domain.Parameters.ReplyMarkupParameters.Keyboards;

public class InlineKeyboardMarkup : Keyboard<InlineKeyboardButton>
{
    [JsonProperty("inline_keyboard", Required = Required.Always)]
    protected override List<List<InlineKeyboardButton>> Buttons { get; set; } = new ();
}