using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public AudioSource music;
    public Button muteButton;
    void Start()
    {

        if(muteButton != null)
        {
            muteButton.onClick.AddListener(() => ChangeMuteSetting());
        }
        
    }

    public void ChangeMuteSetting()
    {
        if(music != null)
            music.mute = !music.mute;
    }


}
