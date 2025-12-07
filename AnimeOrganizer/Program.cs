using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AnimeOrganizer
{
    static class Program
    {
        public static readonly AnimeDB database = new AnimeDB();

        // Try SetProcessDpiAwarenessContext (Per-Monitor V2). Fallback to shcore SetProcessDpiAwareness.
        [DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(IntPtr dpiFlag);

        private static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new IntPtr(-4);

        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(PROCESS_DPI_AWARENESS value);

        private enum PROCESS_DPI_AWARENESS
        {
            PROCESS_DPI_UNAWARE = 0,
            PROCESS_SYSTEM_DPI_AWARE = 1,
            PROCESS_PER_MONITOR_DPI_AWARE = 2
        }

        [STAThread]
        static void Main()
        {
            // Opt in to Per-Monitor V2 DPI awareness if available, otherwise fallback gracefully.
            try
            {
                // Preferred: Per-Monitor V2 (Windows 10+)
                SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
            }
            catch
            {
                try
                {
                    // Fallback: Per-Monitor (shcore). May not provide V2 behavior but better than being unaware.
                    SetProcessDpiAwareness(PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE);
                }
                catch
                {
                    // Ignore - older OS / API not present, app will be treated as DPI-unaware.
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            database.Warmup();
            Application.Run(new Organizer(database));
        }
    }
}