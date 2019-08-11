using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private CharacterController2D player;
    [SerializeField] private float minimumJumpHeight = 300f;
    [SerializeField] private float jumpHeightDecrementer = 10f;
    [SerializeField] private float jumpHeightIncrementer = 20f;

    float startTime;
    float curTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        startTime = Time.fixedTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        curTime = Time.fixedTime;
        if(curTime - startTime < .5)
        {
            player.m_JumpForce += jumpHeightIncrementer;
        }
        else
        {
            if (player.m_JumpForce > minimumJumpHeight)
                player.m_JumpForce -= jumpHeightDecrementer;
            else
                player.m_JumpForce = minimumJumpHeight;
        }
    }
}
