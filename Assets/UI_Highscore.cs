using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_Highscore : MonoBehaviour
{
    public Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (Highscore.highscoreWasSet)
        {
            highscoreText.text = "Highscore: " + Highscore.highscore;
        }
    }
}
