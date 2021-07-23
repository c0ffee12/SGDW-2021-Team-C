using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalletSystem : MonoBehaviour
{
    public int playerBalance;
    public GameObject cat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoldCoin"))
        {
            playerBalance += 3;
        }
        else if (collision.gameObject.CompareTag("SilverCoin"))
        {
            playerBalance += 1;
        }
    }
}
