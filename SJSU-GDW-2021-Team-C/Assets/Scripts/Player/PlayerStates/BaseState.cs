using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{

    public CatFSM FSM;

    public virtual BaseState Initialize(CatFSM FSM)
    {
        this.FSM = FSM;
        return this;
    }

    public virtual void DoState()
    {

    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }
}
