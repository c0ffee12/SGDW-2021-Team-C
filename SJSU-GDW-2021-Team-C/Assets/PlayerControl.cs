namespace PlayerMovement
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class PlayerControlDelegates
    {
        public delegate void EventDelegate(MovementHorizontal m);

        //create eventdelegate for player input
        public static EventDelegate PlayerInput;
    }

    public class PlayerControl : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {

            if (PlayerControlDelegates.PlayerInput == null)
                return;


            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                PlayerControlDelegates.PlayerInput(MovementHorizontal.right);
            } 
            else if(Input.GetAxisRaw("Horizontal") < 0)
            {
                PlayerControlDelegates.PlayerInput(MovementHorizontal.left);
            }
            else
            {
                PlayerControlDelegates.PlayerInput(MovementHorizontal.still);
            }

        }
    }

}

    
