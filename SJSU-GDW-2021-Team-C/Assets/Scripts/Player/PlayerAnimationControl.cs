using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    IEnumerator flicker;
    SpriteRenderer spriteRenderer;
    Animator animator, shadowAnimator;
    float TimeBetweenFlicker = 0.03f;

    // Start is called before the first frame update
    public void Initialize(CatFSM fsm)
    {
        flicker = DamageFlicker(3f);

        GameObject asset = transform.Find("SpringTail/SpringTailHitbox/SpringTailPivot/SpringTailAsset").gameObject;
        GameObject shadowAsset = transform.Find("SpringTail/SpringTailHitbox/SpringTailPivot/SpringTailShadow").gameObject;

        spriteRenderer = asset.GetComponent<SpriteRenderer>();

        animator = asset.GetComponent<Animator>();
        shadowAnimator = shadowAsset.GetComponent<Animator>();

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
        shadowAnimator.SetTrigger("Jumping");
        animator.SetTrigger("Jumping");
    }

    public IEnumerator DamageFlicker(float length)
    {
        for(float i = length; i >= 0; i -= TimeBetweenFlicker)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(TimeBetweenFlicker);
        }

        spriteRenderer.enabled = true;

    }

    public void StartDamageFlicker()
    {
        StopCoroutine(flicker);
        flicker = DamageFlicker(3f);
        StartCoroutine(flicker);
    }

}
