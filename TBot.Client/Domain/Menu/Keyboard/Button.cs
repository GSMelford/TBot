namespace TBot.Client.Domain.Menu.Keyboard;

public class Button
{
    public bool IsPanel { get; set; }
    public Panel? Panel { get; set; }
    
    public string Text { get; set; } = null!;
    public string Code { get; set; } = null!;
    public bool IsEnable { get; set; }
    public int Index { get; set; }
    public int Line { get; set; }
}