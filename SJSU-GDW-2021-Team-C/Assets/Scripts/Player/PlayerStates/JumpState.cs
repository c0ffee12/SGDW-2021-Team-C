using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    float velocityBeforeGrounded;
    float timeDelayAfterJump;
    float speed = 7f;

    public override void BeginState()
    {
        physics.SetTargetLength(1.1f);
        physics.SetStiffness(5f);
        physics.SetSpringiness(23f);

        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 230));

        timeDelayAfterJump = 0f;
        base.BeginState();
    }

    public override void DoState()
    {

        timeDelayAfterJump += Time.deltaTime;


        if(timeDelayAfterJump > 0.15f)
        {
            physics.SetStiffness(20f);
            physics.SetTargetLength(1f);

            if (physics.isGrounded && timeDelayAfterJump > 0.15f)
            {
                FSM.SetState("idleState");
                physics.velocity = velocityBeforeGrounded;
            } else
            {
                velocityBeforeGrounded = GetComponent<Rigidbody2D>().velocity.y;
            }
        }

        
    }

    public override void Move(float horz, bool moving)
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(horz * speed, GetComponent<Rigidbody2D>().velocity.y);
    }


}
