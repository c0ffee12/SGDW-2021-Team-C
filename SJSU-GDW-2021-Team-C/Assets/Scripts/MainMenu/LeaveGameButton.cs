using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaveGameButton : MonoBehaviour
{

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => QuitGame());
    }

    void QuitGame()
    {
        Debug.Log("Exiting game....");
        Application.Quit();
    }
}
