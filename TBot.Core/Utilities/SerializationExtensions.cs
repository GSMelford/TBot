using Newtonsoft.Json;

namespace TBot.Core.Utilities;

public static class SerializationExtensions
{
    public static T? ToObject<T>(this string? value)
    {
        return string.IsNullOrEmpty(value) ? default : JsonConvert.DeserializeObject<T>(value);
    }
    
    public static string ToJson<T>(this T? value)
    {
        return JsonConvert.SerializeObject(value);
    }
}