using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpringTailHitBox"))
        {

            if (this.name.StartsWith("Gold"))
            {
                GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().ChangeMoney(1);
            }
            else
            {
                GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().ChangeMoney(5);
            }
            Destroy(transform.gameObject);
        }
    }
}
