namespace TBot.Client.Domain.Menu;

public class MenuContext
{
    private Panel RootPanel { get; set; }
    
    private MenuContext(Panel panel)
    {
        RootPanel = panel;
    }

    public static MenuContext Create(Panel panel)
    {
        return new MenuContext(panel);
    }

    public Panel? GetPanel(string name)
    {
        return FirstOrDefaultPanel(name, RootPanel);
    }
    
    private Panel? FirstOrDefaultPanel(string name, Panel panel)
    {
        return panel.Name == name 
            ? RootPanel 
            : panel.Buttons.Where(button => button.IsPanel).Select(button => FirstOrDefaultPanel(name, button.Panel!)).FirstOrDefault();
    }
}