using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI to use Text compone
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField]  private GameObject player; // Prefab of the player object
    [SerializeField]  private GameObject menu; // Prefab of the player object
    private Text healthText;
    private bool isPulsed = false;
    private bool unPulsed = false;
    private GameObject playerPrefab; // Prefab of the player object


    void Start(){
        healthText = GetComponent<Text>();
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        menu.SetActive(false);
    }

    void ResumeGame(){
        unPulsed = true; // lets the player un-pulse the game with menu button
    }

    void ReturnToHub(){
        //SceneManager.LoadScene(1);
        //ReturnJump.Jump();
    }

    void QuitGame(){
        Application.Quit(); // lets the player quit the game DOSE NOT WORK FROM THE EDITOR
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-enable the pulse menu GameObject
        menu.SetActive(true);
        Debug.Log("Hello");
    }


    // Update is called once per frame
    void Update()
    {
        //healthText.text = "Health: " + player.GetComponent<Health>().currentHealth.ToString();
        // Check if the Esc key is pressed to toggle pause

        if (Input.GetKeyDown(KeyCode.Escape) && isPulsed == false)
        {
             Time.timeScale = 0f;
             player.GetComponent<PlayerController>().enabled = false;
             menu.SetActive(true);
             isPulsed = true;
             unPulsed = false;
        } else if ((Input.GetKeyDown(KeyCode.Escape) && isPulsed == true) || unPulsed == true){
            Time.timeScale = 1f;
            player.GetComponent<PlayerController>().enabled = true;
            isPulsed = false;
            menu.SetActive(false);
            unPulsed = true;
        }
    }
}
