//Author: Dawid Sklorz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    public class ProgramsController
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        public string currentProgram;
        public int yesPointerProgram = 0;

        public void setStartCurrentProgram(string val)
        {
            System.IO.File.WriteAllText("startCurrentProgram.txt", val);
        }

        public string getStartCurrentProgram()
        {
            return System.IO.File.ReadAllText("startCurrentProgram.txt");
        }

        public string getCurrentProgram()
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);

            if (p.MainWindowTitle.Contains("PowerPoint"))
            {
                currentProgram = "Pp";
            }
            else if (p.MainWindowTitle.Contains("Adobe Acrobat Reader"))
            {
                currentProgram = "Ad";
            }
            else if (p.MainWindowTitle.Contains("Prezentacje Google"))
            {
                if(p.MainWindowTitle.Contains("Google Chrome"))
                {
                    yesPointerProgram = 1;
                }
                currentProgram = "Gs";
            }
            else if (p.MainWindowTitle.Contains("Gestures"))
            {
                currentProgram = "Gt";
            }
            return currentProgram;
        }

        public void zIn_Click(object sender, RoutedEventArgs e)
        {
            sendKey("^{ADD}", "^{ADD}", "", "{PGUP}");
        }

        public void start_Click(object sender, RoutedEventArgs e)
        {
            if (getStartCurrentProgram() != currentProgram)
            {
                System.Diagnostics.Debug.WriteLine("test getStartCurrentProgram() = " + getStartCurrentProgram());
                System.Diagnostics.Debug.WriteLine("test currentProgram = " + currentProgram);

                sendKey("{F5}", "^{h}", "^{F5}", "");
                setStartCurrentProgram(currentProgram);
            }
        }

        public void end_Click(object sender, RoutedEventArgs e)
        {
            sendKey("{ESC}", "{ESC}", "", "");
        }

        public void previous_Click(object sender, RoutedEventArgs e)
        {
            sendKey("{LEFT}", "{Left}", "{LEFT}", "{LEFT}");
        }

        public void next_Click(object sender, RoutedEventArgs e)
        {
            sendKey("{RIGHT}", "{Right}", "{RIGHT}", "{RIGHT}");
        }

        public void zOut_Click(object sender, RoutedEventArgs e)
        {
            sendKey("^{SUBTRACT}", "^{SUBTRACT}", "", "{PGDN}");
        }

        public void first_Click(object sender, RoutedEventArgs e)
        {
            sendKey("{HOME}", "{HOME}", "", "");
        }

        public void last_Click(object sender, RoutedEventArgs e)
        {
            sendKey("{END}", "{END}", "", "");
        }

        public void scroll_up_Click(object sender, RoutedEventArgs e)
        {
            sendKey("{UP}", "{UP}", "", "");
        }

        public void scroll_down_Click(object sender, RoutedEventArgs e)
        {
            sendKey("{DOWN}", "{DOWN}", "", "");
        }

        public void left_Click(object sender, RoutedEventArgs e)
        {
            sendKey("{LEFT}", "{LEFT}", "", "");
        }

        public void right_Click(object sender, RoutedEventArgs e)
        {
            sendKey("{RIGHT}", "{RIGHT}", "", "");
        }

        public void pointer_Mouse(object sender, RoutedEventArgs e)
        {
            sendKey("{}", "{}", "^+{P}", "");
        }

        private void sendKey(string Pp, string Ad, string Gs, string Gt)
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);

            if (p.MainWindowTitle.Contains("PowerPoint"))
            {
                SendKeys.SendWait(Pp);
            }
            else if (p.MainWindowTitle.Contains("Adobe Acrobat Reader"))
            {
                SendKeys.SendWait(Ad);
            }
            else if (p.MainWindowTitle.Contains("Prezentacje Google"))
            {
                SendKeys.SendWait(Gs);
            }
            else if (p.MainWindowTitle.Contains("Gestures"))
            {
                SendKeys.SendWait(Gt);
            }
        }
    }
}
