using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    private AudioSource player;
    public AudioClip[] bgm;

    private void Start()
    {
        player = GetComponent<AudioSource>();
        player.clip = bgm[1];
        player.Play();
    }



}
