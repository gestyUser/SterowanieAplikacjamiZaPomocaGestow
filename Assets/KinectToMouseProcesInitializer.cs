/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Piotr Arent
//Date:         2017-11-21
//Description:  Klasa tworzaca proces sterujacy kursorem za pomoca kinecta
/////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class KinectToMouseProcesInitializer : MonoBehaviour {

    public void StartProcess()
    {
        string fileName = "KinectV2MouseControl.exe";

        Process process = new Process();
        process.StartInfo.FileName = fileName;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        process.Start();
    }

    public void KillProcess()
    {
        Process[] processes = Process.GetProcessesByName("KinectV2MouseControl");
        if (processes.Length > 0)
        {
            processes[0].Kill();
        }
    }
}
