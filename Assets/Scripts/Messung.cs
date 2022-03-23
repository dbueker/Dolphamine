using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Messung
{
    public static string id = "-1";
    public static bool idWasSet = false;
    public static float messungDisc = -1;
    public static float messungCont = -1;
    public static void WriteFile()
    {
        using (StreamWriter writetext = new StreamWriter(Directory.GetCurrentDirectory() + "\\Messung_4-" + id + ".csv", false))
        {
            string messungDiscString = messungDisc.ToString().Replace(",", ".");
            string messungContString = messungCont.ToString().Replace(",", ".");
            string messung = "ID,B,C\n" + id + "," + messungDiscString + "," + messungContString;
            writetext.Write(messung);
            writetext.Close();
        }
    }

}
