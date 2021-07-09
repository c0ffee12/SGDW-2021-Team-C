using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpState : BaseState
{


    private float chargeAmount;


    public override BaseState Initialize(CatFSM fsm)
    {
        
        return base.Initialize(fsm);
    }

    public override void BeginState()
    {
        PlayerControlDelegates.ChargeJump += ChargeJumping;
        GetComponent<PlayerAnimationControl>().SuperJump(true);
        base.BeginState();
        chargeAmount = 0;

    }

    public override void DoState()
    {
        if (chargeAmount < 0.5f)
            chargeAmount += Time.deltaTime;
        else
        {
            ChargeJumping(false);
        }

        base.DoState();

    }


    public override void EndState()
    {
        PlayerControlDelegates.ChargeJump -= ChargeJumping;
        GetComponent<PlayerAnimationControl>().SuperJump(false);
        base.EndState();
    }


    public void ChargeJumping(bool stillCharging)
    {
        if(!stillCharging && FSM.curState == this)
        {
            GetComponent<HighJumpState>().AddExtraJump(chargeAmount);
            FSM.SetState("highJumpState");
        }
    }

    public override void Move(float horz, bool moving)
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(horz * 2f, GetComponent<Rigidbody2D>().velocity.y);
    }

}
