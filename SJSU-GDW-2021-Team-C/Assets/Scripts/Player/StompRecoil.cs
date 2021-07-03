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
            player.AddForce(Vector2.up * GetRecoilStrength());
        }
    }
    private float GetRecoilStrength()
    {
        return Mathf.Abs(player.velocity.y) * 100;
    }
}
