namespace TBot.Client;

public class BotSettings
{
    public string TelegramBotToken { get; }

    public BotSettings(string token)
    {
        TelegramBotToken = token;
    }
    
    protected internal void Validate()
    {
        if (string.IsNullOrEmpty(TelegramBotToken))
        {
            //TODO: Add validation for token length
            throw new ArgumentException("Bot token cannot be empty");
        }
    }
}