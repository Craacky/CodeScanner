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
            string appDataFolderPath = Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData
            );
            string appFolderPath = Path.Combine(appDataFolderPath, "Code Scanner");

            string scannedCodesFolderPath = Path.Combine(appFolderPath, "Scanned Codes");
            string scannedCodesArchiveFolderPath = Path.Combine(
                appFolderPath,
                "Total Scanned Codes"
            );
            if (!Directory.Exists(scannedCodesFolderPath))
            {
                Directory.CreateDirectory(scannedCodesFolderPath);
            }
            if (!Directory.Exists(scannedCodesArchiveFolderPath))
            {
                Directory.CreateDirectory(scannedCodesArchiveFolderPath);
            }

            string configFilePath = Path.Combine(appFolderPath, "config.json");
            List<string> lines =
                new() { "{", "\t\"cameraIp\": \"0.0.0.0\",", "\t\"cameraPort\": 0", "}" };

            if (!File.Exists(configFilePath))
            {
                File.WriteAllLines(configFilePath, lines);
            }
        }
    }
}
