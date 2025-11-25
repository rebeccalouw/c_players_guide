using Terminal.Gui;

static class Ui
{
    private static TextView? _log;
    public static void CreateLogWindow()
    {
        var topBar = new MenuBar(new MenuBarItem[]
        {
            new MenuBarItem("_File", new MenuBarItem[]
            {
                new MenuBarItem("_Quit", "", () => Environment.Exit(0))
            })
        });
        Application.Top.Add(topBar);

        var win = new Window("Boss Battle")
        {
            X = 0, Y = 1, Width = Dim.Fill(), Height = Dim.Fill()
        };

        _log = new TextView
        {
            ReadOnly = true,
            WordWrap = true,
            X = 0, Y = 0,
            Width = Dim.Fill(), Height = Dim.Fill()
        };
        
        win.Add(_log);
        Application.Top.Add (win);
        
        Application.Refresh();
    }

    public static void Log(string text = "")
    {
        if (_log != null)
        {
            var existing = _log.Text.ToString() ?? string.Empty;
            _log.Text = existing + text + Environment.NewLine;
            _log.MoveEnd();
            Application.Refresh();
        }
        else
        {
            Console.WriteLine(text);
        }
    }
}