using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Timer timer;

    public void Start()
    {
        if (!SceneManager.GetActiveScene().name.Contains("Menu") && !SceneManager.GetActiveScene().name.Contains("Spielanleitung"))
        {
            timer = GameObject.Find("Timer").GetComponent<Timer>();
            timer.SetTimerRunning(true);
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void LoadKeyboardScene()
    {
        SceneManager.LoadScene("Keyboard");
    }
    public void LoadKeyboardMenuScene()
    {
        SceneManager.LoadScene("Keyboard_Spielanleitung");
    }
    public void LoadDiscreteScene()
    {
        SceneManager.LoadScene("DiscreteSmile");
    }
    public void LoadDiscreteMenuScene()
    {
        SceneManager.LoadScene("Discrete_Spielanleitung");
    }
    public void LoadContinuousScene()
    {
        SceneManager.LoadScene("ContinuousSmile");
    }
    public void LoadContinuousMenuScene()
    {
        SceneManager.LoadScene("Continuous_Spielanleitung");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void LoadEndMenu()
    {
        SceneManager.LoadScene("EndMenu");
    }

}