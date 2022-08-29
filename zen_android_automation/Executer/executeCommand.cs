using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zen_android_automation.Executer
{
    public class executeCommand
    {
        public string appPath { get; set; } = System.AppDomain.CurrentDomain.BaseDirectory;
        public bool waitForExit { get; set; } = false;
        public bool readLineOutput { get; set; } = false; // If false, automatically set ReadToEnd
        public string program { get; set; } = String.Empty;
        public string args { get; set; } = String.Empty;
        public string runCommand()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;

            startInfo.FileName = program;
            startInfo.Arguments = " " + args;
            process.StartInfo = startInfo;
            process.Start();
            switch (waitForExit)
            {
                case true:
                    process.WaitForExit();
                    break;
            }
            switch (readLineOutput)
            {
                case true:
#pragma warning disable CS8603 // Olası null başvuru dönüşü.
                    return process.StandardOutput.ReadLine();
#pragma warning restore CS8603 // Olası null başvuru dönüşü.
                case false:
                    return process.StandardOutput.ReadToEnd();
            }

        }

    }
}
