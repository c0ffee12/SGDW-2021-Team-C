using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFSM : MonoBehaviour
{

    //Finite state machine: way to add states to player cat object
    //states to add: jump, flying mid-air, landing, afk, etc.
    //extends basestate, which has access to this class
    //add transitions in each state

    public BaseState curState;
    public Dictionary<string, BaseState> states = new Dictionary<string, BaseState>();

    public SpringTailPhysics physics;


    private void Start()
    {
        physics = gameObject.AddComponent<SpringTailPhysics>();
        //create state for idle, attach it to cat, add it to states dictionary
        states.Add("idleState", gameObject.AddComponent<IdleState>().Initialize(this));
        states.Add("jumpState", gameObject.AddComponent<JumpState>().Initialize(this));
        states.Add("highJumpState", gameObject.AddComponent<HighJumpState>().Initialize(this));

        gameObject.AddComponent<PlayerAnimationControl>().Initialize(this);

        SetState("idleState");
    }

    private void FixedUpdate()
    {
        curState.DoState();
    }



    public void SetState(string state)
    {

        //transition between states
        if(curState != null)
        {
            curState.EndState();
        }
            
        curState = states[state];
        curState.BeginState();

    }
}
