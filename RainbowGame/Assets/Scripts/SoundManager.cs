using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource[] sources;
    private AudioSource jump;
    private AudioSource coin;

    public AudioClip JumpSound;
    public AudioClip CoinCollectingSound;
    public AudioClip DeathSound;


    private void Start()
    {
        sources = GetComponents<AudioSource>();
        jump = sources[0];
        coin = sources[1];

        jump.clip = JumpSound;
        coin.clip = CoinCollectingSound;
    }

    public void PlayJumpSound()
    {
        jump.Play();
    }

    public void PlayCoinSound()
    {
        coin.Play();
    }
    
    public void PlayDeathSound()
    {
        return;
    }
}
