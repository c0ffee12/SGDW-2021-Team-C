using EnemyEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    PlayerEnemyEventControl enemyEvents;
    public Rigidbody2D player;
    public Rigidbody2D mouse;

    private void Start()
    {
        enemyEvents = player.gameObject.GetComponent<PlayerEnemyEventControl>();
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
        if (player.position.x > transform.position.x)
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
