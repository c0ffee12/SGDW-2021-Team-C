using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    public Rigidbody2D player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CatBodyHurtBox"))
        {
            if (player.position.x > transform.position.x)
            {
                player.AddForce(Vector2.right * 100);
            }
            else
            {
                player.AddForce(Vector2.left * 100);
            }
            player.AddForce(Vector2.up * 100);
        }
    }
}
