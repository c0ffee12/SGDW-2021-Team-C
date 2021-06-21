using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{

    public override void BeginState()
    {
        FSM.physics.SetTargetLength(1.4f);
    }

}
