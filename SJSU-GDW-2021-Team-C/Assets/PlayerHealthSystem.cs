using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    int health = 10;
    bool currentlyHurt = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MouseHitbox") && !currentlyHurt)
        {
            currentlyHurt = true;
            health -= 2;
            StartCoroutine(Wait());
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        currentlyHurt = false;
    }
}
