using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GestureRecognationInitializer : MonoBehaviour
{

    public void StartProcess()
    {
        Process process = new Process();
        process.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe";
        process.StartInfo.Arguments = "/k cd GesturesRecognation & cd bin & cd x86 & cd Debug & start /min DiscreteGestureBasics-WPF.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        process.Start();
    }

    public void KillProcess()
    {
        Process[] processes = Process.GetProcessesByName("DiscreteGestureBasics-WPF");
        if(processes.Length > 0)
        {
            processes[0].Kill();
        }
    }
}
