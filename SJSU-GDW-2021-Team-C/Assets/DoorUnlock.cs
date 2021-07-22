using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{

    public OnGameEnd gameEnd;
    public string NextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpringTailHitBox")&& 
            GameObject.Find("SpringTailHitbox").GetComponent<PlayerCollectibles>().hasKey1)
        {

            gameEnd.StartLevelEnd(NextScene);

            Destroy(transform.parent.gameObject);
            Debug.Log("DOOR UNLOCKED");
        }
    }
}
