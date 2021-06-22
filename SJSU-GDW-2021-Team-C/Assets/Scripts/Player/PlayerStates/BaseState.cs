using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{

    public CatFSM FSM;
    public SpringTailPhysics physics;

    public virtual BaseState Initialize(CatFSM FSM)
    {
        this.FSM = FSM;
        physics = FSM.physics;

        

        return this;
    }

    public virtual void DoState()
    {

    }

    public virtual void BeginState()
    {
        PlayerMovement.PlayerControlDelegates.PlayerInput += Move;
    }

    public virtual void EndState()
    {
        PlayerMovement.PlayerControlDelegates.PlayerInput -= Move;
    }

    public virtual void Move(float horz, bool moving)
    {

    }
}
