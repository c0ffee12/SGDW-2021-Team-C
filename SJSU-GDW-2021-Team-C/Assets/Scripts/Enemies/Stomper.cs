using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{

    CatFSM catFSM;

    private void Start()
    {
        catFSM = GameObject.FindGameObjectWithTag("Player").GetComponent<CatFSM>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("SpringTailHitBox") && !(catFSM.curState is PlayerTakeDamageState))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
