namespace TBot.Telegram.Dto.Types;

public class ChatIdentifier
{
    private readonly int? _identifier;
    private readonly string? _username;

    private ChatIdentifier(string username)
    {
        _username = username;
    }
        
    private ChatIdentifier(int identifier)
    {
        _identifier = identifier;
    }
        
    public static implicit operator ChatIdentifier(int identifier)
    {
        return new ChatIdentifier(identifier);
    }
        
    public static implicit operator ChatIdentifier(string username)
    {
        return new ChatIdentifier(username);
    }

    public override string ToString()
    {
        return _username ?? _identifier.ToString() ?? throw new Exception("Chat Id not set");
    }
}