using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    GameManager gm;
    public Text scoreText;

    // set it to true when gameplay has started, to false when level finished or game paused
    private bool timerRunning = false;
    public void SetTimerRunning(bool value) { timerRunning = value; }

    private float remainingTime = 90F;
    private float scoreTimer = 0F;
    public int score = 0;

    PythonStarter python;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        python = GameObject.Find("GameManager").GetComponent<PythonStarter>();
        score = 0;
    }

    private void Update()
    {
        if (timerRunning)
        {
            remainingTime -= Time.deltaTime;
            scoreTimer += Time.deltaTime;

            if (scoreTimer >= 0.1F)
            {
                score += 1;
                scoreTimer = 0F;
                scoreText.text = "Score: " + score.ToString();
            }
            
        }
        if (remainingTime <= 0F)
        {
            Highscore.SetHighscore(score);
            Score.SetEndOfRoundScore(score);
            gm.LoadEndMenu();

            if (SceneManager.GetActiveScene().name != "Keyboard")
            {
                python.quitCMD();
            }
        }
    }

    public void ReduceScore(int value)
    {
        score = score - value;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int value)
    {
        score = score + value;
        scoreText.text = "Score: " + score.ToString();
    }
}
