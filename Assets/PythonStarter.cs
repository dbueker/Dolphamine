using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class PythonStarter : MonoBehaviour
{
    SmileReceiver receiver;
    Process proc;
    // Start is called before the first frame update
    void Start()
    {
        receiver = GameObject.Find("SmileReceiver").GetComponent<SmileReceiver>();
        UnityEngine.Debug.Log(Directory.GetCurrentDirectory());

        if (SystemInfo.operatingSystem.Contains("Windows"))
        {
            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Minimized,
                    WorkingDirectory = Directory.GetCurrentDirectory() + @"\Assets\Scripts\SmileDetectionForUnity\",
                    Arguments = "/C python SmileDetector.py"
                }
            };
            proc.Start();
        }

        else
        {
            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    WorkingDirectory = Directory.GetCurrentDirectory() + @"/Assets/Scripts/SmileDetectionForUnity/",
                    Arguments = " -c \"" + "python SmileDetector.py" + " \""
                }
            };
            proc.Start();
        }
    }

    public void quitCMD()
    {
        receiver.SendGameOver();
        proc.Close();
    }

}
