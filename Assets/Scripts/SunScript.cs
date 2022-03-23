using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    Timer timer;
    ScoreMinus scoreMinus;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        scoreMinus = GameObject.Find("ScoreMinus").GetComponent<ScoreMinus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("cloud"))
        {
            timer.ReduceScore(25);
            scoreMinus.Enable();
        }
    }   

}
