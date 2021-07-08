using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayingUI
{
    public class ExitGame : MonoBehaviour
    {
        GameObject escapeMenu;
        Button button;

        private void Start()
        {
            escapeMenu = transform.parent.transform.parent.gameObject;
            button = GetComponent<Button>();
            button.onClick.AddListener(() => Exit());

        }

        void Exit()
        {
            Application.Quit();
        }
    }
}

