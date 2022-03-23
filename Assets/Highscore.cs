using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Highscore
{
    public static int highscore = 0;
    public static bool highscoreWasSet = false;    

    public static void SetHighscore(int newHighscore)
    {
        highscoreWasSet = true;
        if (newHighscore > highscore)
        {
            highscore = newHighscore;
        }
    }
}
