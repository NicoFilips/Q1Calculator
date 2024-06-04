using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Q1Calculator.UI.Helpers;

public static class Window
{
    public const int MinWidth = 400;
    public const int MinHeight = 520;

    private const int SW_RESTORE = 9;


    [DllImport("user32.dll")]
    private static extern bool IsIconic(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

    public static void RestoreWindow()
    {
        Process? runningProcess = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)
            .FirstOrDefault(p => p.Id != Process.GetCurrentProcess().Id);

        if (runningProcess is null)
            return;
        IntPtr ptr = runningProcess.MainWindowHandle;

        if (IsIconic(ptr))
            ShowWindowAsync(ptr, SW_RESTORE);
    }
}
