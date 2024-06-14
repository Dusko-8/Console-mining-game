using System;
using System.Runtime.InteropServices;

public class ConsoleWindowSettings
{
    // Import user32.dll to use Windows API functions
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int nIndex);

    private const uint SWP_NOZORDER = 0x0004;
    private const uint SWP_NOSIZE = 0x0001;
    private const int GWL_STYLE = -16;
    private const int WS_SIZEBOX = 0x00040000;
    private const int WS_MAXIMIZEBOX = 0x00010000;

    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    public static void ApplySettings(int consoleWidth, int consoleHeight)
    {
        // Set the desired console window size
        Console.SetWindowSize(consoleWidth, consoleHeight);

        // Get the handle of the current console window
        IntPtr consoleHandle = GetForegroundWindow();

        // Get the screen dimensions using System parameters
        int screenWidth = GetSystemMetrics(0); // SM_CXSCREEN
        int screenHeight = GetSystemMetrics(1); // SM_CYSCREEN

        // Get the current console window dimensions
        GetWindowRect(consoleHandle, out RECT rect);
        int windowWidth = rect.Right - rect.Left;
        int windowHeight = rect.Bottom - rect.Top;

        // Calculate the position to center the console window on the screen
        int posX = (screenWidth / 2) - (windowWidth / 2);
        int posY = (screenHeight / 2) - (windowHeight / 2);

        // Set the position of the console window
        SetWindowPos(consoleHandle, IntPtr.Zero, posX, posY, 0, 0, SWP_NOZORDER | SWP_NOSIZE);

        // Disable resizing and maximizing
        int style = GetWindowLong(consoleHandle, GWL_STYLE);
        style &= ~WS_SIZEBOX; // Remove the sizing border
        style &= ~WS_MAXIMIZEBOX; // Remove the maximize button
        SetWindowLong(consoleHandle, GWL_STYLE, style);

        // Verify settings
        style = GetWindowLong(consoleHandle, GWL_STYLE);
    }
}
