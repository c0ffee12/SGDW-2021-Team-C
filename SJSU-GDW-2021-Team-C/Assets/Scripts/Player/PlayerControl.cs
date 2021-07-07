namespace PlayerMovement
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class PlayerControlDelegates
    {

        public delegate void TakeDamageDelegate(bool Direction);

        public delegate void EventDelegate(float horz, bool moving);
        public delegate void JumpDelegate(bool jump);
        public delegate void Bounce();
        //create eventdelegate for player input
        public static EventDelegate PlayerInput;
        public static JumpDelegate PlayerJump;
        public static Bounce bounce;

        public static TakeDamageDelegate TakeDamage;
    }

    public class PlayerControl : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {

            if (PlayerControlDelegates.PlayerInput == null)
                return;


            PlayerControlDelegates.PlayerInput(Input.GetAxis("Horizontal"), Input.GetAxisRaw("Horizontal") != 0);

            if (Input.GetButtonDown("Jump"))
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

    
