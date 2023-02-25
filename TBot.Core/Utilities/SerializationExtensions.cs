using Newtonsoft.Json;

namespace TBot.Core.Utilities;

public static class SerializationExtensions
{
    public static async Task<T> ToRequiredObjectAsync<T>(this HttpResponseMessage response)
    {
        return (await response.Content.ReadAsStringAsync()).ToRequiredObject<T>();
    } 
    
    public static async Task<T?> ToObjectAsync<T>(this HttpResponseMessage response)
    {
        return (await response.Content.ReadAsStringAsync()).ToObject<T>();
    } 
    
    public static T ToRequiredObject<T>(this HttpResponseMessage response)
    {
        return response.Content.ReadAsStringAsync().Result.ToRequiredObject<T>();
    } 
    
    public static T? ToObject<T>(this HttpResponseMessage response)
    {
        return response.Content.ReadAsStringAsync().Result.ToObject<T>();
    } 
    
    public static T ToRequiredObject<T>(this string value)
    {
        return JsonConvert.DeserializeObject<T>(value)!;
    }
    
    public static T? ToObject<T>(this string value)
    {
        return JsonConvert.DeserializeObject<T>(value);
    }
}