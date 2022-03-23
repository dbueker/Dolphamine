using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterPhysics : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerBody;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -2)
        {
            playerBody.drag = 13;
        }
        else
        {
            playerBody.drag = 0;
        }
        
    }
}
