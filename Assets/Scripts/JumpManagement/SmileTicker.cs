using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmileTicker : MonoBehaviour
{
    SmileReceiver smileReceiver;
    JumpManager jumpManager;
    PlayerMovement playerMovement;
    Slider jumpbar;

    float minJumpForce;
    float maxJumpForce;
    float checkForSmileInterval = 0.2F;

    float jumpForce;
    float jumpForceInterval;
    bool jumpIsCharging = false;

    int smileCounter = 0;
    public float smileDurationRound = 0;
    public List<float> smilesList;

    // Start is called before the first frame update
    void Start()
    {
        smileReceiver = GameObject.Find("SmileReceiver").GetComponent<SmileReceiver>();
        jumpManager = GameObject.Find("JumpManager").GetComponent<JumpManager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        jumpbar = GameObject.Find("Jumpbar").GetComponent<Slider>();

        minJumpForce = jumpManager.minJumpForce;
        maxJumpForce = jumpManager.maxJumpForce;
        jumpForceInterval = (maxJumpForce - minJumpForce) / 4;
        jumpbar.minValue = minJumpForce;
        jumpbar.maxValue = maxJumpForce;
        jumpForce = minJumpForce;

        smilesList = new List<float>();

        InvokeRepeating("CheckForSmile", 0.001F, checkForSmileInterval);

    }

    void CheckForSmile()
    {

        if (jumpForce < maxJumpForce)
        {
            if (smileReceiver.smileReceived && playerMovement.canJump) // Init Jump-Loading-Sequence
            {
                jumpForce += jumpForceInterval;
                jumpIsCharging = true;
                jumpbar.value += jumpForceInterval;
                smileCounter += 1;
            }
            else if (jumpIsCharging && playerMovement.canJump) // Weak Jump
            {
                jumpManager.RequestJump(jumpForce);
                jumpIsCharging = false;
                jumpForce = minJumpForce;
                jumpbar.value = jumpbar.minValue;

                smilesList.Add(smileCounter * checkForSmileInterval); // Calc length of continuous smile and add to list
                smileDurationRound += (smileCounter * checkForSmileInterval); // Calc length of continuous smile duration
                smileCounter = 0;
            }
            smileReceiver.smileReceived = false;
        }

        else if (jumpForce >= maxJumpForce)
        {
            if (smileReceiver.smileReceived && playerMovement.canJump) // Hold Max Jump
            {
                jumpIsCharging = true;
                smileCounter += 1;
            }
            else if (jumpIsCharging && playerMovement.canJump) // Max Jump
            {
                jumpManager.RequestJump(jumpManager.maxJumpForce);
                jumpIsCharging = false;
                jumpForce = minJumpForce;
                jumpbar.value = jumpbar.minValue;

                smilesList.Add(smileCounter * checkForSmileInterval); // Calc length of continuous smile and add to list
                smileDurationRound += (smileCounter * checkForSmileInterval); // Calc length of continuous smile duration
                smileCounter = 0;
            }
            smileReceiver.smileReceived = false;
        }
    }

}