using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public bool canJump = true;
    Timer timer;
    ScoreMinus scorePlus;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        scorePlus = GameObject.Find("ScorePlus").GetComponent<ScoreMinus>();

        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GroundWall")
        {
            canJump = true;
            Debug.Log("canJump ist true");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GroundWall")
        {
            canJump = false;
            Debug.Log("canJump ist false");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("cloud"))
        {
            timer.IncreaseScore(50);
            scorePlus.Enable();
        }
    }

    public void Jump(float force)
    {
        rigidBody.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
    }
}
