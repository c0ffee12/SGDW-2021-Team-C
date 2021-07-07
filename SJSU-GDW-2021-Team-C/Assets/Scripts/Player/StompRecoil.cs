using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompRecoil : MonoBehaviour
{
    public Rigidbody2D player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MouseHurtbox"))
        {
            player.velocity = new Vector2(player.velocity.x, 10);
        }
    }
}
