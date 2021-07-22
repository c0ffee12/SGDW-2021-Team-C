using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    float timeAfterLanded;
    bool jumping = true;


    public override BaseState Initialize(CatFSM FSM)
    {

        return base.Initialize(FSM);
    }

    public override void BeginState()
    {

        //PlayerControlDelegates.ChargeJump += OnChargeJump;
        PlayerControlDelegates.PlayerJump += Jump;

        physics.SetTargetLength(1f);
        physics.SetSpringiness(20f);
        physics.SetStiffness(4f);

        
        physics.velocity = GetComponent<Rigidbody2D>().velocity.y * 0.2f;

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        
        base.BeginState();

        timeAfterLanded = 0f;
    }

    public override void EndState()
    {
        //PlayerControlDelegates.ChargeJump -= OnChargeJump;
        base.EndState();
    }

    public override void DoState()
    {

        timeAfterLanded += Time.deltaTime;
    }

    public void OnChargeJump(bool charging)
    {
        if(charging)
        {
            FSM.SetState("SuperJumpState");
        }
    }

    public override void Move(float horz, bool moving)
    {

        if (FSM.physics.isGrounded && moving)
        {
            if(!jumping)
            {
                GetComponent<JumpState>().InitializeJump();
                FSM.SetState("jumpState");
                
            }
            else
            {
                GetComponent<HighJumpState>().InitializeJump();
                FSM.SetState("highJumpState");
            }
            
        }

    }

    public void Jump(bool isJumping)
    {
        this.jumping = isJumping;
    }



}
