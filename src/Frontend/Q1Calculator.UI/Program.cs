using MudBlazor.Services;
using Q1Calculator.UI.Helpers;
using MudBlazor;
using MudExtensions.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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
        builder.Services.AddLogging();
        builder.Services.AddMudLocalization();
        builder.Services.AddMudServices();
        builder.Services.AddMudExtensions();
        builder.RootComponents.Add<Main>("body");


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

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };

        app.Run();
    }
}
