using TBot.Client.Domain.Menu.Keyboard;

namespace TBot.Client.Domain.Menu;

public class Panel
{
    public string Name { get; set; } = null!;
    public List<Button> Buttons { get; set; } = new ();
}