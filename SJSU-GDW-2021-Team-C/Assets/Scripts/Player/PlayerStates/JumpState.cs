using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    float velocityBeforeGrounded;
    float timeDelayAfterJump;

    public override void BeginState()
    {
        physics.SetTargetLength(1.4f);
        physics.SetStiffness(20f);
        physics.SetSpringiness(5f);

        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));

        timeDelayAfterJump = 0f;
        base.BeginState();
    }

    public override void DoState()
    {

        
        Debug.Log(GetComponent<Rigidbody2D>().velocity.y);
        timeDelayAfterJump += Time.deltaTime;


        if(timeDelayAfterJump > 0.15f)
        {
            physics.SetStiffness(5f);
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

    public override void Move(MovementHorizontal m)
    {

        if (m == MovementHorizontal.left)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(m==MovementHorizontal.right)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, GetComponent<Rigidbody2D>().velocity.y);
        }

        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

}
