using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------------Audio Source---------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("---------------Audio Clip-----------------")]

    public AudioClip menuMusic;
    public AudioClip walk;

    public void Awake()
    {
        musicSource.clip = menuMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        sfxSource.PlayOneShot(clip);
    }
}
