using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static bool spawned = false;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject managers;
    [SerializeField] public GameObject inventory;
    [SerializeField] public GameObject camera;
    [SerializeField] public GameObject eventSystem;

    void Awake()
    {
        //if (scene.buildIndex != 5 && scene.buildIndex != 6) Time.timeScale = 0f;
        Time.timeScale = 0f;

        if(spawned == false){
            spawned = true;
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(managers);
            DontDestroyOnLoad(camera);
            DontDestroyOnLoad(eventSystem);
        } else {
            Destroy(player);
            Destroy(managers);
            Destroy(camera);
            Destroy(eventSystem);
            Destroy(gameObject);
        }
    }

        void Start()
        {
            // Subscribe to the sceneLoaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Check if the loaded scene is not a menu scene
            if (scene.buildIndex != 5 && scene.buildIndex != 6)
            {
                // Activate player and camera
                //player.SetActive(true);
                //player.GetComponent<Rigidbody2D>().FreezeX = false;
                //player.GetComponent<Rigidbody2D>().FreezeY = false;
                //Time.timeScale = 0f;
                Time.timeScale = 1f;
                camera.SetActive(true);
            }
            else
            {
                // Deactivate player and camera
                //player.SetActive(false);
                //player.GetComponent<Rigidbody2D>().FreezeX = true;
                //player.GetComponent<Rigidbody2D>().FreezeY = true;
                Time.timeScale = 0f;
                camera.SetActive(false);
            }
        }

        void OnDestroy()
        {
            // Unsubscribe from the sceneLoaded event
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

}
