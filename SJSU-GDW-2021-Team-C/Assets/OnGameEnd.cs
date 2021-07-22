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
    public bool ending = false;
    float timeDelay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ending)
        {
            PlayerControlDelegates.PlayerInput(1, true);
            PlayerControlDelegates.PlayerJump(false);

            timeDelay += Time.deltaTime;

            if(timeDelay >= 5)
            {
                control.OnSceneUnload();
                SceneManager.LoadScene(SceneToLoad);
            }

        }
        
    }

    public void StartLevelEnd(string SceneToLoad)
    {
        this.SceneToLoad = SceneToLoad;
        camera.transform.parent = null;
        ending = true;


    }
}
