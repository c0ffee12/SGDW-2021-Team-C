using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            GameObject.Find("CatBodyHitbox").GetComponent<PlayerHealthSystem>().health += 4;
            if(GameObject.Find("CatBodyHitbox").GetComponent<PlayerHealthSystem>().health > 10)
            {
                GameObject.Find("CatBodyHitbox").GetComponent<PlayerHealthSystem>().health = 10;
            }
            Debug.Log(GameObject.Find("CatBodyHitbox").GetComponent<PlayerHealthSystem>().health);
        }
    }
}
