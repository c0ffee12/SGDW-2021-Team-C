using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{


    public override void BeginState()
    {
        FSM.physics.SetTargetLength(1.4f);
    }

    public override void DoState()
    {
        if(FSM.physics.isGrounded)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, 5f);
        }
    }

}
