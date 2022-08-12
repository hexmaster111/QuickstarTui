using Terminal.Gui;


namespace QuickStarTui // Note: actual namespace depends on the project name.
{
    public static class Program
    {
        private static Window win;

        public static void Main(string[] args)
        {
            if (args.Length > 0 && args.Contains("-usc"))
            {
                Application.UseSystemConsole = true;
            }
            
            Application.Init();
            
            win = new Window("QuickStarTui")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 1
            };
            CommunicationDisplay.Setup();
            ApplicationRoot.Setup(win);
            
            var progress = new ProgressBar (new Rect (68, 1, 3, 1));
            Application.MainLoop.AddTimeout(TimeSpan.FromMilliseconds(50), (MainLoop loop) =>
            {
                //hacky way to get the application to keep refreshing the ui
                progress.Pulse();
                return true;
            });
            win.Add(progress);
            
            win.Add(ApplicationRoot.Logo());
            

            Application.Top.Add(win, ApplicationRoot.MenuBar(), ApplicationRoot.StatusBar());
            
            Application.Run(); //ANYTHING PAST THIS IS NON-UI CODE FOR SHUTDOWN AND CLEANUP
            Application.Shutdown();
        }
    }
}