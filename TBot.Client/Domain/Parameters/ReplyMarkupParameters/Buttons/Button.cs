using Newtonsoft.Json;

namespace TBot.Client.Domain.Parameters.ReplyMarkupParameters.Buttons;

public class Button
{
    [JsonProperty("text", Required = Required.Always)]
    public string Text { get; set; } = null!;
}