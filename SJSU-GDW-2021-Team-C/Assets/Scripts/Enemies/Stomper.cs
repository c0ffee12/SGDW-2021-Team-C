using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("SpringTailHitBox"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
