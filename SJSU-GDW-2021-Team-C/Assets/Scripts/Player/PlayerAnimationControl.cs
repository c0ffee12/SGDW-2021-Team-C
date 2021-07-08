using EnemyEvents;
using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    IEnumerator flicker;
    SpriteRenderer spriteRenderer, shadowSpriteRenderer;
    Animator animator, shadowAnimator;
    float TimeBetweenFlicker = 0.03f;


    private void OnEnable()
    {

        Debug.Log("created");

        flicker = DamageFlicker(3f);

        GameObject asset = transform.Find("SpringTail/SpringTailHitbox/SpringTailPivot/SpringTailAsset").gameObject;
        GameObject shadowAsset = transform.Find("SpringTail/SpringTailHitbox/SpringTailPivot/SpringTailShadow").gameObject;

        spriteRenderer = asset.GetComponent<SpriteRenderer>();
        shadowSpriteRenderer = shadowAsset.GetComponent<SpriteRenderer>();

        animator = asset.GetComponent<Animator>();
        shadowAnimator = shadowAsset.GetComponent<Animator>();

        PlayerControlDelegates.PlayerInput += Move;
        PlayerControlDelegates.bounce += Jump;
    }

    // Start is called before the first frame update
    public void Initialize(CatFSM fsm)
    {
        
    }

    public void Move(float horz, bool moving)
    {

        if(spriteRenderer == null)
        {
            return;
        }

        if(horz < 0)
        {
            shadowSpriteRenderer.flipX = true;
            spriteRenderer.flipX = true;
        }
        else if (horz > 0)
        {
            shadowSpriteRenderer.flipX = false;
            spriteRenderer.flipX = false;
        }

    }

    public void Jump()
    {
        shadowAnimator.SetTrigger("Jumping");
        animator.SetTrigger("Jumping");
    }

    public void SuperJump(bool value)
    {
        shadowAnimator.SetBool("ChargeJump", value);
        animator.SetBool("ChargeJump", value);
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
        flicker = DamageFlicker(GetComponent<PlayerEnemyEventControl>().InvulnDuration);
        StartCoroutine(flicker);
    }

}
