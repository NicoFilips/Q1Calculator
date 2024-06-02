using MudBlazor.Services;
using Q1Calculator.UI.Helpers;
using Photino.Blazor;
using Q1Calculator.UI.Components;


namespace Q1Calculator.UI;

public class Program
{
    private const string AppGuid = "";

    [STAThread]
    private static void Main(string[] args)
    {
        using var Mutex = new Mutex(true, AppGuid, out bool shouldRun);

        if (!shouldRun)
        {
            Window.RestoreWindow();
            Console.WriteLine("Another instance of the application is already running.");
            return;
        }

        var builder = PhotinoBlazorAppBuilder.CreateDefault(args);
        builder.Services.AddRazorComponents();
        builder.RootComponents.Add<Main>("body");

        builder.Services.AddMudServices();

        PhotinoBlazorApp app = builder.Build();

        app.MainWindow.Resizable = false;

        app.MainWindow
           .SetLogVerbosity(0)
           .SetContextMenuEnabled(false)
           .SetDevToolsEnabled(false)
           .SetTitle("Quality1 Calculator")
           .SetIconFile("wwwroot/icons/calculator.ico")
           .Center()
           .SetMinSize(Window.MinWidth, Window.MinHeight)
           .SetSize(Window.MinWidth, Window.MinHeight)
           .SetMaximized(false)
           .SetFullScreen(false)
           .SetUseOsDefaultLocation(false)
           .SetUseOsDefaultSize(false);

#if DEBUG
        app.MainWindow.SetDevToolsEnabled(true);
#endif

        app.Run();
    }
}
