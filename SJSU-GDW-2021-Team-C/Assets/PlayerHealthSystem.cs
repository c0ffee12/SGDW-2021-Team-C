using EnemyEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    int health = 10;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MouseHitbox") && !gameObject.GetComponent<PlayerEnemyEventControl>().PlayerInvulnerable())
        {
            health -= 2;
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
