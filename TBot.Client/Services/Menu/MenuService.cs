using Microsoft.Extensions.Options;
using TBot.Client.Domain.Menu;
using TBot.Client.Domain.Parameters;
using TBot.Client.Domain.Parameters.ReplyMarkupParameters.Buttons;
using TBot.Client.Domain.Parameters.ReplyMarkupParameters.Keyboards;
using TBot.Client.Domain.TBot;

namespace TBot.Client.Services.Menu;

public class MenuService
{
    private readonly MenuContext _menuContext;
    private readonly ITBotClient _tBotClient;

    public MenuService(IOptionsSnapshot<RootPanelOption> panelRootOption, ITBotClient tBotClient)
    {
        _menuContext = MenuContext.Create(panelRootOption.Get(RootPanelOption.OptionName).Panel);
        _tBotClient = tBotClient;
    }

    private async Task SendMenuAsync(string name)
    {
        var panel = _menuContext.GetPanel(name);
        if (panel is null) {
            return;
        }
        
        var maxLine = panel.Buttons.Max(x=>x.Line) + 1;
        var keyboard = new ReplyKeyboardMarkup { OneTimeKeyboard = true, ResizeKeyboard = true };

        for (int i = 0; i < maxLine; i++)
        {
            bool isMenuButtonAdded = false;
            var maxIndex = panel.Buttons.Where(x=>x.Line == i).Max(x=>x.Index) + 1;
            for (int j = 0; j < maxIndex; j++)
            {
                var i1 = i;
                var j1 = j;
                
                var menuButtons = 
                    panel.Buttons.Where(x => x.Line == i1 && x.Index == j1);

                foreach (var menuButton in menuButtons)
                {
                    if (!menuButton.IsEnable)
                    {
                        continue;
                    }
                    
                    isMenuButtonAdded = true;
                    keyboard.Add(new KeyboardButton
                    {
                        Text = menuButton.Text
                    });
                }
            }

            if (i + 1 != maxLine && isMenuButtonAdded) 
                keyboard.AddNextLine();
        }

        await _tBotClient.SendMessageAsync(new SendMessageParameters
        {
            Text = panel.Name,
            ReplyMarkup = keyboard,
            ChatId = 0
        });
    }
}