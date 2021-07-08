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
        if (chargeAmount < 2f)
            chargeAmount += Time.deltaTime;

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

}
