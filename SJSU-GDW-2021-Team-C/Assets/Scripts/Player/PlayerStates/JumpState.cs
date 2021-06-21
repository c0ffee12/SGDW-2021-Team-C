using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{

    float timeDelayAfterJump;

    public override void BeginState()
    {
        physics.SetTargetLength(2f);
        physics.SetStiffness(3f);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 200));


        timeDelayAfterJump = 0f;
    }

    public override void DoState()
    {

        timeDelayAfterJump += Time.deltaTime;

        if(physics.isGrounded && timeDelayAfterJump > 0.15f)
        {
            FSM.SetState("idleState");
        }
    }

}
