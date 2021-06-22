using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{

    float timeAfterLanded;
    public override void BeginState()
    {
        physics.SetTargetLength(1f);
        physics.SetSpringiness(20f);
        physics.SetStiffness(4f);

        
        physics.velocity = GetComponent<Rigidbody2D>().velocity.y * 0.2f;
        base.BeginState();

        timeAfterLanded = 0f;
    }

    public override void DoState()
    {
        timeAfterLanded += Time.deltaTime;
    }

    public override void Move(MovementHorizontal m)
    {
        if (FSM.physics.isGrounded && m != MovementHorizontal.still)
        {
            FSM.SetState("jumpState");
        }
    }

}
