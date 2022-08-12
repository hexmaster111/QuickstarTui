using Terminal.Gui;

namespace QuickStarTui;

public class Dialogs
{
    /// <summary>
    /// Asks the user if they would like to quit the application.
    /// </summary>
    /// <param name="message">what to write to the user</param>
    /// <returns>true on yes</returns>
    public static bool YesNo(String message)
    {
        var n = MessageBox.Query(50, 7, "Quit?", message, "Yes", "No");
        return n == 0;
    }
}