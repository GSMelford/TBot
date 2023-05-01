namespace TBot.Client;

public class BotSettings
{
    public string BotToken { get; }

    public BotSettings(string token)
    {
        BotToken = token;
    }
    
    protected internal void Validate()
    {
        if (string.IsNullOrEmpty(BotToken))
        {
            //TODO: Add validation for token length
            throw new ArgumentException("Bot token cannot be empty");
        }
    }
}