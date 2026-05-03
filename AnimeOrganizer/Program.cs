using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using AnimeOrganizerCommon;
using AnimeOrganizerDataObjects;

namespace AnimeOrganizer
{
    static class Program
    {
        // Use the interface so we can swap implementations in Program.Main
        public static IAnimeDB database;

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

            // Initialize the ZeddPath from application settings
            UtillExtensions.ZeddPath = Properties.Settings.Default.zeddPath;

            // Debug-only: optionally clean AppData when running under the debugger (Visual Studio).
            TryCleanAppDataWhenDebugging();

            // Choose a debug-friendly DB implementation when running under the debugger.
#if DEBUG
            if (Debugger.IsAttached)
            {
                database = new InMemoryAnimeDB();
            }
            else
            {
                database = new AnimeDB();
            }
#else
            database = new AnimeDB();
#endif

            database.Warmup();
            Application.Run(new Organizer(database));
            //Application.Run(new Forms.QuickOrganizerV2());
        }

        // Runs only in DEBUG builds and only if a debugger is attached.
        // Asks the developer for confirmation and then deletes files and subdirectories
        // inside the app's AppData folder. This keeps the action explicit and reversible.
        private static void TryCleanAppDataWhenDebugging()
        {
#if DEBUG
            if (!Debugger.IsAttached) return;

            var appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AnimeOrganizer");
            if (!Directory.Exists(appDataDir)) return;

            var msg = "Clean application data in:\n\n" + appDataDir + "\n\nThis will delete files and subfolders used by the app for debugging. Continue?";
            var res = MessageBox.Show(msg, "Clean AppData (Debug only)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;

            try
            {
                // Delete files
                foreach (var file in Directory.GetFiles(appDataDir))
                {
                    try { File.Delete(file); }
                    catch (Exception exFile) { Debug.WriteLine("Failed to delete file: " + file + " - " + exFile.Message); }
                }

                // Delete subdirectories
                foreach (var dir in Directory.GetDirectories(appDataDir))
                {
                    try { Directory.Delete(dir, true); }
                    catch (Exception exDir) { Debug.WriteLine("Failed to delete directory: " + dir + " - " + exDir.Message); }
                }

                Debug.WriteLine("AppData cleanup completed for: " + appDataDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("AppData cleanup failed: " + ex.Message, "Cleanup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
        }
    }
}