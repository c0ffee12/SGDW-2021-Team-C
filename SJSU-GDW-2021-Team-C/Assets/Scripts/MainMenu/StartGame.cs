using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public string NextScene = "LivingRoomScene";

    void Start()
    {
        Button button = GetComponent<Button>();
        if(button != null)
        {
            button.onClick.AddListener(() => OnButton());
        }
        
    }

    void OnButton()
    {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
    }

}
