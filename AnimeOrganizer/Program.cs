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
            try
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
                string savedPath = Properties.Settings.Default.zeddPath;
                if (string.IsNullOrWhiteSpace(savedPath))
                {
                    // If no path is saved, prompt user to select one
                    using (var folderDialog = new FolderBrowserDialog())
                    {
                        folderDialog.Description = "Please select your Anime folder";
                        if (folderDialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                        {
                            MessageBox.Show("No folder was selected. The application will now close.", "Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        savedPath = folderDialog.SelectedPath;
                        Properties.Settings.Default.zeddPath = savedPath;
                        Properties.Settings.Default.Save();
                    }
                }
                UtillExtensions.ZeddPath = savedPath;

                // Set AppData path: use a separate debug folder in DEBUG mode to avoid affecting production data
                SetAppDataPath();

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
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred during startup:\n\n{ex.Message}\n\nPlease check your application settings and try again.\n\nDetails: {ex.InnerException?.Message}",
                    "Startup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Sets the AppData folder path: uses a separate "Debug" subfolder when running in DEBUG mode.
        // This prevents debug data from mixing with or overwriting production data.
        private static void SetAppDataPath()
        {
            string baseAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AnimeOrganizer");

#if DEBUG
            if (Debugger.IsAttached)
            {
                baseAppData = Path.Combine(baseAppData, "Debug");
                // Create the debug subfolder if it doesn't exist
                if (!Directory.Exists(baseAppData))
                {
                    Directory.CreateDirectory(baseAppData);
                }
            }
#endif

            // Store this in a static location or update your app's configuration
            // to use this path for all AppData operations
            AppDataPath = baseAppData;
        }

        // Static property to hold the AppData path for use throughout the application
        public static string AppDataPath { get; set; }
    }
}