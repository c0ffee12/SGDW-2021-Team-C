using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpState : JumpState
{
    public override void BeginState()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 350));
        base.BeginState();
    }
}
