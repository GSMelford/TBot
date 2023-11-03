namespace TBot.Client;

public class BotOptions
{
    public string BotToken { get; set; } = null!;
    public string UpdatePath { get; set; } = null!;
    public UpdateOptions? UpdateOptions { get; set; }
    
    
    protected internal void Validate()
    {
        if (string.IsNullOrEmpty(BotToken))
        {
            //TODO: Add validation for token length
            throw new ArgumentException("Bot token cannot be empty");
        }
    }
}

public class UpdateOptions
{
    public int Limit { get; set; }
    public int TimeoutSeconds { get; set; }
}