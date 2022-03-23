using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudConstantMove : MonoBehaviour
{
    //private Animator anim;

    Vector3 moveVector;
    int moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveVector = new Vector3(-1, 0, 0);
        moveSpeed = 3;

        //anim = GetComponent<Animator>();
      }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        if (transform.position.x <= -9)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //anim.Play("PopAnimation");
            //Debug.Log("play anim");
            Destroy(gameObject);

        }
        /*else if (collision.gameObject.name == "Sun")
        {
            Destroy(gameObject);
        }*/
    }

}