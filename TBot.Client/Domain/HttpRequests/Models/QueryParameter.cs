namespace TBot.Client.Domain.HttpRequests.Models;

public class QueryParameter
{
    public string Key { get; }
    public object? Value { get; }
    public UrlEncode UrlEncode { get; }
        
    public QueryParameter(
        string key, 
        object? value, 
        UrlEncode urlEncode = UrlEncode.NoEncode)
    {
        Key = key;
        Value = value;
        UrlEncode = urlEncode;
    }
}