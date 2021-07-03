using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Animator animator;

    // Start is called before the first frame update
    public void Initialize(CatFSM fsm)
    {
        GameObject asset = transform.Find("SpringTail/SpringTailHitbox/SpringTailPivot/SpringTailAsset").gameObject;
        spriteRenderer = asset.GetComponent<SpriteRenderer>();
        animator = asset.GetComponent<Animator>();

        PlayerControlDelegates.PlayerInput += Move;
        PlayerControlDelegates.bounce += Jump;
    }

    public void Move(float horz, bool moving)
    {

        if(horz < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horz > 0)
        {
            spriteRenderer.flipX = false;
        }

    }

    public void Jump()
    {
        animator.SetTrigger("Jumping");
    }

}
