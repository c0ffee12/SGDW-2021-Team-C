using EnemyEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    PlayerEnemyEventControl enemyEvents;
    private bool canAttack = true;
    public Rigidbody2D player;
    public Rigidbody2D mouse;

    private void Start()
    {
        enemyEvents = player.gameObject.GetComponent<PlayerEnemyEventControl>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CatBodyHurtBox") && canAttack)
        {
            canAttack = false;
            CatPushBack();
            StartCoroutine(Wait());
        }
    }
    private void CatPushBack()
    {
        Debug.Log("Pushback");
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
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
