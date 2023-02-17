namespace TBot.Core.Utilities;

public static class UsefulMethod
{
    public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T>? collection)
    {
        return collection ?? Array.Empty<T>();
    }
}