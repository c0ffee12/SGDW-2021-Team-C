using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayingUI
{
    public class MenuController : MonoBehaviour
    {

        bool EscMenuOpen;
        public GameObject EscapeMenu, PlayingMenu;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnEscape();
            }

        }


        public void OnEscape()
        {

            if (!EscMenuOpen)
            {
                EscapeMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                EscapeMenu.SetActive(false);
                Time.timeScale = 1;
            }

            EscMenuOpen = !EscMenuOpen;
        }
    }

}
