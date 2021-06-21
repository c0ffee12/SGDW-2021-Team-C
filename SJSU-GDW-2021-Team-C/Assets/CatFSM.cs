using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFSM : MonoBehaviour
{

    public BaseState curState;
    public Dictionary<string, BaseState> states = new Dictionary<string, BaseState>();

    public SpringTailPhysics physics;


    private void Start()
    {
        physics = gameObject.AddComponent<SpringTailPhysics>();
        states.Add("idleState", gameObject.AddComponent<IdleState>().Initialize(this));

        SetState("idleState");
    }

    private void Update()
    {
        curState.DoState();
    }



    public void SetState(string state)
    {
        if(curState != null)
        {
            curState.EndState();
        }
            
        curState = states[state];
        curState.BeginState();

    }
}
