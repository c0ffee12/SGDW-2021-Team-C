using EnemyEvents;
using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{
    public int health; //actually means 3
    public GameObject cat;

    public void TakeDamage()
    {
        health -= 1;
        PlayerControlDelegates.onHealthChange(health);
    }

    public void RestoreHealth()
    {
        if(health < 3)
        {
            health++;
        }
        PlayerControlDelegates.onHealthChange(health);
    }

    private void Update()
    {
        if(health <= 0)
        {
            GameObject.Find("GameController").GetComponent<OnGameEnd>().StartLevelEnd(SceneManager.GetActiveScene().name, true);
            GameObject.Find("Player").GetComponent<PlayerControl>().OnSceneUnload();
            GameObject.Destroy(GameObject.Find("Player").GetComponent<AudioSource>());
            GameObject.Destroy(GameObject.Find("SpringTailAsset").GetComponent<SpriteRenderer>());
            GameObject.Destroy(GameObject.Find("SpringTailShadow").GetComponent<SpriteRenderer>());
            GameObject.Find("Main Camera").transform.parent = null;
            
        }
    }
}
