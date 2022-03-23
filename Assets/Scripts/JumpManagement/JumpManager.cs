using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    PlayerMovement playerMovement;

    private bool jumpWasRequested = false;
    private float jumpForce = 0F;

    public float minJumpForce = 14F;
    public float maxJumpForce = 20F;
    public int smileCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpWasRequested)
        {
            playerMovement.Jump(jumpForce);
            smileCounter += 1;
            jumpWasRequested = false;
        }
    }

    public void RequestJump(float force)
    {
        jumpForce = force;

        if (playerMovement.canJump)
        {
            jumpWasRequested = true;
        }
    }
}
