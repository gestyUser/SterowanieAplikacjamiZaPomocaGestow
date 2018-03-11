//Author: Dawid Sklorz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    public class ProcessManager
    {
        private string processName;
        private Process[] processes;

        public ProcessManager(string processName)
        {
            this.processName = processName;
            this.processes = Process.GetProcessesByName(this.processName);
        }

        public void checkProcess(bool onlyKill = false)
        {
            if (this.processes.Length > 0)
                killProcess();
            else
                if(!onlyKill)
                    initiateProcess(this.processName);
        }

        public void initiateProcess(string processName)
        {
            string path = Path.GetFullPath(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            Process process = new Process();
            process.StartInfo.FileName = path + processName;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.Start();
        }

        public void killProcess()
        {
            this.processes[0].Kill();
        }
    }
}
