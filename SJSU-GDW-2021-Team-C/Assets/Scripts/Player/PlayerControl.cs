namespace PlayerMovement
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class PlayerControlDelegates
    {
        public delegate void EventDelegate(float horz, bool moving);
        public delegate void JumpDelegate(bool jump);

        //create eventdelegate for player input
        public static EventDelegate PlayerInput;
        public static JumpDelegate PlayerJump;
    }

    public class PlayerControl : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {

            if (PlayerControlDelegates.PlayerInput == null)
                return;


            PlayerControlDelegates.PlayerInput(Input.GetAxis("Horizontal"), Input.GetAxisRaw("Horizontal") != 0);

            if (Input.GetButton("Jump"))
            {
                PlayerControlDelegates.PlayerJump(true);
            }
            if(Input.GetButtonUp("Jump"))
            {
                PlayerControlDelegates.PlayerJump(false);
            }

        }
    }

}

    
