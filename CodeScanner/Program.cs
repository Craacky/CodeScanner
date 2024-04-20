using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace CodeScanner
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FilesInitilization();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI());
        }

        static void FilesInitilization()
        {
            string appFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Code Scanner"
            );
            string scannedCodesFolderPath = Path.Combine(appFolderPath, "Scanned Codes");
            string scannedCodesArchiveFolderPath = Path.Combine(
                appFolderPath,
                "Total Scanned Codes"
            );
            DirectoryHandler(appFolderPath);
            DirectoryHandler(scannedCodesFolderPath);
            DirectoryHandler(scannedCodesArchiveFolderPath);
            string configFilePath = Path.Combine(appFolderPath, "config.json");
            List<string> lines =
                new() { "{", "\t\"cameraIP\": \"0.0.0.0\",", "\t\"cameraPort\": 0", "}" };

            if (!File.Exists(configFilePath))
            {
                File.WriteAllLines(configFilePath, lines);
            }
        }

        static void DirectoryHandler(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
