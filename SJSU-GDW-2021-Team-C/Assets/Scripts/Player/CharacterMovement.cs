namespace PlayerMovement
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CharacterMovement : MonoBehaviour
    {
        Rigidbody2D rb;
        SpriteRenderer sprite;
        
        void Start()
        {
            //gat various components attached to the cat
            rb = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();

            //subscribe movement to PlayerControl
            //PlayerControlDelegates.PlayerInput += MovePlayer;

        }

        void MovePlayer(MovementHorizontal m)
        {
            switch(m)
            {
                case MovementHorizontal.left:
                    sprite.flipX = false;
                    rb.velocity = new Vector2(-1, rb.velocity.y);
                    break;

                case MovementHorizontal.right:
                    sprite.flipX = true;
                    rb.velocity = new Vector2(1, rb.velocity.y);
                    break;

                case MovementHorizontal.still:
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    break;
            }
        }
    }

}
