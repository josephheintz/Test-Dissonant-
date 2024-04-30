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
    [SerializeField] public GameObject mainCamera;
    [SerializeField] public GameObject eventSystem;
    [SerializeField] public GameObject healthUI;

    void Awake()
    {
        //if (scene.buildIndex != 5 && scene.buildIndex != 6) Time.timeScale = 0f;
        Time.timeScale = 0f;

        if(spawned == false){
            spawned = true;
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(managers);
            DontDestroyOnLoad(mainCamera);
            DontDestroyOnLoad(eventSystem);
        } else {
            Destroy(player);
            Destroy(managers);
            Destroy(mainCamera);
            Destroy(eventSystem);
            Destroy(gameObject);
        }
    }

        void Start()
        {
            // Subscribe to the sceneLoaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
            Time.timeScale = 0f;
        }

        void Update(){
            if(player.GetComponent<PlayerController>().Health <= 0) {
            SceneManager.LoadScene(23);
            player.GetComponent<PlayerController>().Health = player.GetComponent<PlayerController>().maxHealth;
            healthUI.GetComponent<HeartController>().SetFilledHearts();
            }
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Check if the loaded scene is not a menu scene
            if (scene.buildIndex != 5 && scene.buildIndex != 6 && scene.buildIndex != 7)
            {
                // Activate time
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
            }
        }

        void OnDestroy()
        {
            // Unsubscribe from the sceneLoaded event
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

}
