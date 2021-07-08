using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamageState : BaseState
{
    float speed = 4f;
    float timeDelay;
    public bool KnockbackLeft;

    public override void TakeDamage(bool left)
    {
        //don't take damage if already taken damage
        return;
    }

    public override BaseState Initialize(CatFSM FSM)
    {

        return base.Initialize(FSM);

    }

    public override void BeginState()
    {
        timeDelay = 0f;
        GetComponent<PlayerAnimationControl>().StartDamageFlicker();
        GetComponent<Rigidbody2D>().velocity = new Vector2(5 * (KnockbackLeft ? 1 : -1), 10);
        base.BeginState();
    }

    public override void DoState()
    {
        timeDelay += Time.deltaTime;
        if(GetComponent<SpringTailPhysics>().isGrounded && timeDelay >= 0.1f)
        {
            FSM.SetState("idleState");
        }

        base.DoState();
    }

    public override void Move(float horz, bool moving)
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(2 * (KnockbackLeft ? 1 : -1) + horz * speed, GetComponent<Rigidbody2D>().velocity.y);
    }

}
