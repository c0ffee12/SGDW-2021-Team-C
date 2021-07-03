using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpState : JumpState
{
    public override void BeginState()
    {
        base.BeginState();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, 12);
        
    }
}
