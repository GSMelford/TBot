namespace TBot.Core;

public static class BotUtilities
{
    public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T>? collection)
    {
        return collection ?? Array.Empty<T>();
    }
}