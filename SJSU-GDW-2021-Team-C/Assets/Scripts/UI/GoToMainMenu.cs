using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlayingUI
{
    public class GoToMainMenu : MonoBehaviour
    {
        Button button;
        PlayerControl control;


        private void Start()
        {
            control = GameObject.Find("Player").GetComponent<PlayerControl>();

            button = GetComponent<Button>();
            button.onClick.AddListener(() => MainMenu());

        }

        void MainMenu()
        {
            Time.timeScale = 1;
            control.OnSceneUnload();
            SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
        }
    }
}

