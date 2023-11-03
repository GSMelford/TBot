using System.Text.Json;
using Newtonsoft.Json;

namespace TBot.Client.Utilities;

public static class SerializationExtensions
{
    public static T? ToObject<T>(this string? value)
    {
        return string.IsNullOrEmpty(value) ? default : JsonConvert.DeserializeObject<T>(value);
    }

    internal static async Task<T?> DeserializeAsync<T>(this Stream stream)
    {
        return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions());
    }
    
    public static string ToJson<T>(this T? value)
    {
        return JsonConvert.SerializeObject(value);
    }
}