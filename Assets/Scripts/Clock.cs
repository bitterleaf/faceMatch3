using UnityEngine;
using System.Runtime.InteropServices;


public class Clock : MonoBehaviour {

    [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi)]
    public static extern void GetSystemTimePreciseAsFileTime(out long filetime);

    public static void write(string str)
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\datalogs\\unity_faces\\test.txt", true);
        file.WriteLine(str);

        file.Close();
    }

    //automate the time stamping. Slight loss of precision is possible (but unlikely).
    public static void markEvent(string str)
    {
        long fTest;
        GetSystemTimePreciseAsFileTime(out fTest);
		System.DateTime dt = new System.DateTime(1601, 01, 01).AddTicks(fTest);
		dt = dt.ToLocalTime();
		write(str + " " + dt.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
    }

}
