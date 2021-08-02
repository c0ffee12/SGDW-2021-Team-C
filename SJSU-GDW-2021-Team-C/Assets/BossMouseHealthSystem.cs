using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouseHealthSystem : MonoBehaviour
{
    public SpriteRenderer sRend;
    CatFSM catFSM;
    BossMovement BossMouse;
    public bool canTakeDamage;
    public int Bosshealth;
    public bool Invincible;

    private void Start()
    {
        sRend = GetComponentInParent<SpriteRenderer>();
        canTakeDamage = true;
        BossMouse = GameObject.FindGameObjectWithTag("BossMouse").GetComponent<BossMovement>();
        catFSM = GameObject.FindGameObjectWithTag("Player").GetComponent<CatFSM>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Invincible && collision.gameObject.CompareTag("SpringTailHitBox") && !(catFSM.curState is PlayerTakeDamageState) && (BossMouse.speed <= 2))
        {
            Bosshealth -= 1;
            OnTakeDamage();

            if (Bosshealth <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
            if(Bosshealth % 3 == 0)
            {
                BossMouse.PanicMode();
                Debug.Log("PANIC MODE ACTIVATED");
            }
        }
    }

    public void OnTakeDamage()
    {
        StartCoroutine(FlickerOnDamage());
    }
    float IFrameLength = 2f;
    float t = 0;
    public IEnumerator FlickerOnDamage()
    {
        
        Invincible = true;
        
        if(t < IFrameLength)
        {
            yield return new WaitForSeconds(0.01f);
            t += 0.01f;
            sRend.enabled = !sRend.enabled;
            StartCoroutine(FlickerOnDamage());
        }
        else
        {
            t = 0;
            Invincible = false;
            sRend.enabled = true;
        }

    }

}
