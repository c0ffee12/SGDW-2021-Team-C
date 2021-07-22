using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieTouchingDeathPlane : MonoBehaviour
{
    public OnGameEnd gameEnd;

    public void Start()
    {
        gameEnd = GameObject.Find("GameController").GetComponent<OnGameEnd>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);

        if(collider.gameObject.tag == "DeathPlane")
        {
            gameEnd.StartLevelEnd(SceneManager.GetActiveScene().name);
        }

    }
}
