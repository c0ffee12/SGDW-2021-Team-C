using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpringTailHitBox")&& 
            GameObject.Find("SpringTailHitbox").GetComponent<PlayerCollectibles>().hasKey1)
        {
            Destroy(transform.parent.gameObject);
            Debug.Log("DOOR UNLOCKED");
        }
    }
}
