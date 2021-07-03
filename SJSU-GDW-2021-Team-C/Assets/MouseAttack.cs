using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    private bool canAttack = true;
    public Rigidbody2D player;
    public Rigidbody2D mouse;

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
        if (player.position.x > transform.position.x)
        {
            player.AddForce(Vector2.right * 300);
        }
        else
        {
            player.AddForce(Vector2.left * 300);
        }
        player.AddForce(Vector2.up * 200);
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
