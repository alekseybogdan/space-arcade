using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip playerExplosion;
    public AudioClip asteroidExplosion;
    public AudioClip difficultyIncrease;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAsteroidExplosion()
    {
        _audioSource.PlayOneShot(asteroidExplosion);
    }

    public void PlayPlayerExplosion()
    {
        _audioSource.PlayOneShot(playerExplosion);
    }

    public void PlayDifficultyIncrease()
    {
        _audioSource.PlayOneShot(difficultyIncrease);
    }
}
