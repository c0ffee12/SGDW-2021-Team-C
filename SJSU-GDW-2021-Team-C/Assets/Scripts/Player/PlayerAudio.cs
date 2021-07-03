using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] springClips;
    void Start()
    {

        source = GetComponent<AudioSource>();
        springClips = GetComponent<PlayerSpringClips>().SpringClips;

        PlayerControlDelegates.bounce += PlayAudioOnJump;

    }

    void PlayAudioOnJump()
    {

        if(springClips.Length > 0)
        {
            source.clip = springClips[Random.Range(0, springClips.Length)];
            source.Play();
        }
    }
}
