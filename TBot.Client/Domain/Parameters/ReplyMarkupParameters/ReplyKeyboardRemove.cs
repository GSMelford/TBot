using Newtonsoft.Json;
using TBot.Client.Parameters.ReplyMarkupParameters;

namespace TBot.Client.Domain.Parameters.ReplyMarkupParameters;

public class ReplyKeyboardRemove : ReplyMarkup
{
    [JsonProperty("remove_keyboard", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool RemoveKeyboard { get; set; }
    
    [JsonProperty("selective", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool Selective { get; set; }
}