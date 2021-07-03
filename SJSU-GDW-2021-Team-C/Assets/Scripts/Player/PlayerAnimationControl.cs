using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    public void Initialize(CatFSM fsm)
    {
        spriteRenderer = transform.Find("SpringTail/SpringTailHitbox/SpringTailPivot/SpringTailAsset").gameObject.GetComponent<SpriteRenderer>();
        PlayerControlDelegates.PlayerInput += Move;
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

}
