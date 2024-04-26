using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("---------------Audio Source---------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource playerSFXSource;
    [SerializeField] AudioSource WorldSFXSource;
    [SerializeField] AudioSource mobSFXSource;

    [Header("---------------Music-----------------")]
    public AudioClip menuMusic;
    [Header("---------------Fantasy Music---------------")]
    public AudioClip OuterGardenMusic;
    public AudioClip treeTopMusic;
    public AudioClip rockRootMusic;
    public AudioClip castleMusic;
    [Header("-------------Hub Music-----------------")]
    public AudioClip hubMusic;
    public AudioClip hub1Music;
    [Header("-------------Sci-Fi Music----------------------")]
    public AudioClip dockingBayMusic;
    public AudioClip AICoreMusic;
    public AudioClip hiveMusic;
    public AudioClip reactorMusic;
    [Header("-------------Hell Music-------------------------")]
    public AudioClip fireFallMusic;
    public AudioClip livingRuinMusic;
    public AudioClip theKingMusic;
    public AudioClip theRightHandMusic;
    [Header("--------------Ocean Music----------------------")]
    public AudioClip farShoreMusic;
    public AudioClip iceyCaveMusic;
    public AudioClip iceyShoreMusic;
    public AudioClip theDeepMusic;
    [Header("--------------Player Sounds----------------------")]
    public AudioClip playerJump;
    public AudioClip playerAttack;
    public AudioClip playerTakeDamage;
    public AudioClip itemPickup;
    public AudioClip portalIn;
    public AudioClip portalOut;
    [Header("--------------Mob Sounds---------------")]
    public AudioClip slimeTakeDamage;
    public AudioClip slimeDeath;
    public AudioClip fantasyBossDamage;
    public AudioClip fantasyBossAttack;
    public AudioClip fantasyBossDeath;
    public AudioClip skeletonDamage;
    public AudioClip skeletonAttack;
    public AudioClip skeletonDeath;

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
        else if (scene.name == "DockingBay")
        {
            musicSource.clip = dockingBayMusic;
            musicSource.Play();
        }
        else if (scene.name == "Hive")
        {
            musicSource.clip = hiveMusic;
            musicSource.Play();
        }
        else if (scene.name == "AICore")
        {
            musicSource.clip = AICoreMusic;
            musicSource.Play();
        }
        else if (scene.name == "Reactor")
        {
            musicSource.clip = reactorMusic;
            musicSource.Play();
        }
        else if (scene.name == "FireFall")
        {
            musicSource.clip = fireFallMusic;
            musicSource.Play();
        }
        else if (scene.name == "LiveingRuin")
        {
            musicSource.clip = livingRuinMusic;
            musicSource.Play();
        }
        else if (scene.name == "TheKing")
        {
            musicSource.clip = theKingMusic;
            musicSource.Play();
        }
        else if (scene.name == "TheRightHand")
        {
            musicSource.clip = theRightHandMusic;
            musicSource.Play();
        }
        else if (scene.name == "FarShore")
        {
            musicSource.clip = farShoreMusic;
            musicSource.Play();
        }
        else if (scene.name == "IceyCave")
        {
            musicSource.clip = iceyCaveMusic;
            musicSource.Play();
        }
        else if (scene.name == "IceyShore")
        {
            musicSource.clip = iceyShoreMusic;
            musicSource.Play();
        }
        else if (scene.name == "TheDeep")
        {
            musicSource.clip = theDeepMusic;
            musicSource.Play();
        }
    }

    

    // Unsubscribe from the event when the object is destroyed
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public void PlayPSFX(AudioClip clip) {
        playerSFXSource.clip = clip;
        playerSFXSource.Play();
    }
    public void PlayWSFX(AudioClip clip)
    {
        WorldSFXSource.clip = clip;
        WorldSFXSource.Play();
    }
    public void PlayMSFX(AudioClip clip)
    {
        mobSFXSource.clip = clip;
        mobSFXSource.Play();
    }
}
