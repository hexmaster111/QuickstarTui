using System.Text;
using NStack;
using Terminal.Gui;

namespace QuickStarTui;

public static class ApplicationRoot
{
    private static Window _window;

    public static void Setup(Window win)
    {
        _window = win;
    }


    public static MenuBar MenuBar()
    {
        var menu = new MenuBar(new[]
        {
            new MenuBarItem("[_S]etup", new MenuItem[]
            {
                new MenuItem("[_C]ommunication", "Hub Serial Settings",
                    () => MessageBox.Query(50, 7, "Setup", "Setting up", "Ok")),
            })
        });
        return menu;
    }

    public static StatusBar StatusBar()
    {
        var statusBar = new StatusBar(new StatusItem[]
        {
            new StatusItem(Key.F1, "~F1~ Help", () => MessageBox.Query(50, 7, "Help", "Helping", "Ok")),
            new StatusItem(Key.F2, "[~F2~] Debug Button", CommunicationDisplay.DebugChangeConnectionStatus),
            new StatusItem(Key.F3, "~F3~ Save", () => MessageBox.Query(50, 7, "Save", "Saving", "Ok")),
            new StatusItem(Key.CtrlMask | Key.Q, "~^Q~ Quit", () =>
            {
                if (Dialogs.YesNo("Really Exit QuickStar?")) Application.Top.Running = false;
            }),
            CommunicationDisplay.RxIndicator(),
            CommunicationDisplay.TxIndicator(),
            CommunicationDisplay.ConnectionStatus(),
        });
        return statusBar;
    }


    public static Label Logo()
    {
        Label logo = new Label()
        {
            ColorScheme = Colors.Base,
            X = 0,
            Y = 0,
            Height = 10,
            Width = 70,
            AutoSize = false
        };
        
        var block = new StringBuilder();

        block.AppendLine("░██████╗░██╗░░░██╗██╗░█████╗░██╗░░██╗░██████╗████████╗░█████╗░██████╗░ ");
        block.AppendLine("██╔═══██╗██║░░░██║██║██╔══██╗██║░██╔╝██╔════╝╚══██╔══╝██╔══██╗██╔══██╗ ");
        block.AppendLine("██║██╗██║██║░░░██║██║██║░░╚═╝█████═╝░╚█████╗░░░░██║░░░███████║██████╔╝ ");
        block.AppendLine("╚██████╔╝██║░░░██║██║██║░░██╗██╔═██╗░░╚═══██╗░░░██║░░░██╔══██║██╔══██╗ ");
        block.AppendLine("░╚═██╔═╝░╚██████╔╝██║╚█████╔╝██║░╚██╗██████╔╝░░░██║░░░██║░░██║██║░░██║ ");
        block.AppendLine("░░░╚═╝░░░░╚═════╝░╚═╝░╚════╝░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝ ");
        block.AppendLine("    █▄▄ █▄█   █▀▄▀█ █▀█ █▄░█ █ █▀▀ █▀   █▀ █▄█ █▀ ▀█▀ █▀▀ █▀▄▀█ █▀ ");
        block.AppendLine("    █▄█ ░█░   █░▀░█ █▄█ █░▀█ █ █▄▄ ▄█   ▄█ ░█░ ▄█ ░█░ ██▄ █░▀░█ ▄█ ");
        logo.Text = ustring.Make(block.ToString());

        return logo;
    }
}