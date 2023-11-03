namespace TBot.Client;

public class TBotOptions
{
    public string BotToken { get; set; }
    public string UpdatePath { get; set; }

    public TBotOptions()
    {
        
    }
    
    public TBotOptions(string token)
    {
        BotToken = token;
    }
    
    public TBotOptions(string token, string updatePath)
    {
        BotToken = token;
        UpdatePath = updatePath;
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