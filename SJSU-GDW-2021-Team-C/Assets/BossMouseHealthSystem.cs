using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouseHealthSystem : MonoBehaviour
{
    CatFSM catFSM;
    BossMovement BossMouse;
    public bool canTakeDamage;
    public int Bosshealth;

    private void Start()
    {
        canTakeDamage = true;
        BossMouse = GameObject.FindGameObjectWithTag("BossMouse").GetComponent<BossMovement>();
        catFSM = GameObject.FindGameObjectWithTag("Player").GetComponent<CatFSM>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpringTailHitBox") && !(catFSM.curState is PlayerTakeDamageState) && (BossMouse.speed <= 2))
        {
            Bosshealth -= 1;
            if (Bosshealth <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
            if(Bosshealth == 5 || Bosshealth == 2)
            {
                BossMouse.PanicMode();
                Debug.Log("PANIC MODE ACTIVATED");
            }
        }
    }
}
