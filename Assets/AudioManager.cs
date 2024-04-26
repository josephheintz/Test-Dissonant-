using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("---------------Audio Source---------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("---------------Music-----------------")]
    public AudioClip menuMusic;
    public AudioClip OuterGardenMusic;
    public AudioClip treeTopMusic;
    public AudioClip rockRootMusic;
    public AudioClip castleMusic;
    public AudioClip hubMusic;
    public AudioClip hub1Music;
    [Header("--------------Player Sounds---------------")]
    public AudioClip playerJump;
    public AudioClip playerAttack;
    public AudioClip playerTakeDamage;
    public AudioClip itemPickup;
    public AudioClip portalIn;
    public AudioClip portalOut;
    [Header("--------------Mob Sounds---------------")]
    public AudioClip slimeTakeDamage;
    public AudioClip slimeDeath;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
        musicSource.clip = menuMusic;
        musicSource.Play(); // Play menu music by default
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        musicSource.Stop();
        // Check the scene name and play the corresponding music
        if (scene.name == "StartScreen")
        {
            musicSource.clip = menuMusic;
            musicSource.Play();
        }
        else if (scene.name == "HubStart")
        {
            musicSource.clip = hubMusic;
            musicSource.Play();
        }
        else if (scene.name == "Hub1")
        {
            musicSource.clip = hub1Music;
            musicSource.Play();
        }
        else if (scene.name == "OuterGarden")
        {
            musicSource.clip = OuterGardenMusic;
            musicSource.Play();
        }
        else if (scene.name == "TreeTop")
        {
            musicSource.clip = treeTopMusic;
            musicSource.Play();
        }
        else if (scene.name == "RockRoots")
        {
            musicSource.clip = rockRootMusic;
            musicSource.Play();
        }
        else if (scene.name == "Castle")
        {
            musicSource.clip = castleMusic;
            musicSource.Play();
        }

    }

    

    // Unsubscribe from the event when the object is destroyed
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public void PlaySFX(AudioClip clip) {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
}
