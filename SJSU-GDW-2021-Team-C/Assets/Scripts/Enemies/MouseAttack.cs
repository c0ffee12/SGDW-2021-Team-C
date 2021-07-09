using EnemyEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    PlayerEnemyEventControl enemyEvents;
    public GameObject player;

    private void Start()
    {
        enemyEvents = player.GetComponent<PlayerEnemyEventControl>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CatBodyHurtBox") && !enemyEvents.PlayerInvulnerable())
        {
            CatPushBack();
        }
    }
    private void CatPushBack()
    {
        bool KnockbackLeft;
        if (player.transform.position.x > transform.position.x)
        {
            KnockbackLeft = true;
        }
        else
        {
            KnockbackLeft = false;
        }
        enemyEvents.PlayerTakeDamage(KnockbackLeft);
    }
}
