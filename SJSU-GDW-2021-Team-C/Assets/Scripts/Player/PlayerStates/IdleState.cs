using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{

    float timeAfterLanded;
    public override void BeginState()
    {
        physics.SetTargetLength(1.4f);
        //physics.SetSpringiness(20f);
        base.BeginState();

        timeAfterLanded = 0f;
    }

    public override void DoState()
    {
        timeAfterLanded += Time.deltaTime;
    }

    public override void Move(MovementHorizontal m)
    {
        if (FSM.physics.isGrounded && timeAfterLanded > 2f)
        {
            FSM.SetState("jumpState");
        }
    }

}
