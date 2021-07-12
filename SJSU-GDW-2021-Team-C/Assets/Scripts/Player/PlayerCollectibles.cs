using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    public bool hasKey1 = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key1"))
        {
            hasKey1 = true;
            Debug.Log("KEY1 COLLECTED SUCCESFULLY");
        }
    }
}
