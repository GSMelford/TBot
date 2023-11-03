using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace TBot.Client.Utilities;

public static class SerializationExtensions
{
    public static T? ToObject<T>(this string? value)
    {
        return string.IsNullOrEmpty(value) ? default : JsonConvert.DeserializeObject<T>(value);
    }
    
    public static T? Deserialize<T>(this Stream stream)
    {
        var serializer = new JsonSerializer();
        using var streamReader = new StreamReader(stream);
        using var jsonTextReader = new JsonTextReader(streamReader);
        return serializer.Deserialize<T>(jsonTextReader);
    }
    
    public static string ToJson<T>(this T? value)
    {
        return JsonConvert.SerializeObject(value);
    }
}