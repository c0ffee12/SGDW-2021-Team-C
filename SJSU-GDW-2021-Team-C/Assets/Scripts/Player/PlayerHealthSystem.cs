using EnemyEvents;
using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public int health; //actually means 3
    public GameObject cat;

    public void TakeDamage()
    {
        health -= 1;
        PlayerControlDelegates.onHealthChange(health);
    }

    public void RestoreHealth()
    {
        if(health < 3)
        {
            health++;
        }
        PlayerControlDelegates.onHealthChange(health);
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
