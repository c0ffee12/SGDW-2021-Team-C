using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{

    float velocityBeforeGrounded;
    float timeDelayAfterJump;
    float speed = 7f;
    public bool doubleJump = false;
    public bool addedDoubleJump;

    public override void BeginState()
    {
        PlayerControlDelegates.PlayerJump += ExtraJump;

        if(PlayerControlDelegates.bounce != null)
            PlayerControlDelegates.bounce();

        physics.SetTargetLength(1.1f);
        physics.SetStiffness(5f);
        physics.SetSpringiness(23f);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, 5);

        base.BeginState();
    }

    public override void DoState()
    {

        timeDelayAfterJump += Time.deltaTime;


        if(timeDelayAfterJump > 0.15f)
        {

            PlayerControlDelegates.PlayerJump -= ExtraJump;
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

        if(timeDelayAfterJump >= 0.22f)
        {
            if(!addedDoubleJump)
            {
                addedDoubleJump = true;
                PlayerControlDelegates.ChargeJump += DoubleJump;
            }

            
        }


        
    }

    public override void EndState()
    {
        timeDelayAfterJump = 0f;
        addedDoubleJump = false;
        PlayerControlDelegates.ChargeJump -= DoubleJump;
        PlayerControlDelegates.PlayerJump -= ExtraJump;
        base.EndState();
    }

    public override void Move(float horz, bool moving)
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(horz * speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void ExtraJump(bool jump)
    {
        if(jump)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 12);
        }
    }

    public void InitializeJump()
    {
        doubleJump = false;
    }

    public void DoubleJump(bool jump)
    {
        if(jump && doubleJump == false)
        {
            doubleJump = true;
            FSM.SetState("highJumpState");
        }
    }


}
