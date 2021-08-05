using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnGameEnd : MonoBehaviour
{
    public string SceneToLoad;
    public PlayerControl control;
    public GameObject camera;
    public bool ending = false, dead = false, stopMoving = false;
    float timeDelay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Player").GetComponent<PlayerControl>();
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(ending)
        {
            if(dead)
            {
                GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().ResetMoney();
            }

            if(!dead && !stopMoving)
            {

                if (PlayerControlDelegates.PlayerInput != null)
                    PlayerControlDelegates.PlayerInput(1, true);

                if (PlayerControlDelegates.PlayerJump != null)
                    PlayerControlDelegates.PlayerJump(false);
            }
            else
            {
                if (PlayerControlDelegates.PlayerInput != null)
                    PlayerControlDelegates.PlayerInput(0, false);

                if (PlayerControlDelegates.PlayerJump != null)
                    PlayerControlDelegates.PlayerJump(false);
            }
            

            timeDelay += Time.deltaTime;

            if(timeDelay >= 5)
            {
                control.OnSceneUnload();
                SceneManager.LoadScene(SceneToLoad);
            }

        }
        
    }

    public void StartLevelEnd(string SceneToLoad, bool dead = false, bool justStopMoving = false)
    {
        this.dead = dead;
        this.SceneToLoad = SceneToLoad;
        camera.transform.parent = null;
        this.stopMoving = justStopMoving;
        ending = true;


    }
}
