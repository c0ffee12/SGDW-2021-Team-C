using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("SpringTailHitBox"))
        {
            GameObject.Find("Player").GetComponent<PlayerHealthSystem>().RestoreHealth();
            Destroy(transform.gameObject);
        }
    }
}
