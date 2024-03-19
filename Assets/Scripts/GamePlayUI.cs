using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI to use Text compone

public class GamePlayUI : MonoBehaviour
{
    [SerializeField]  private GameObject player; // Prefab of the player object
    [SerializeField]  private GameObject menu; // Prefab of the player object
    private Text healthText;
    private bool isPulsed = false;
    private bool unPulsed = false;


    void Start(){
        healthText = GetComponent<Text>();
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        menu.SetActive(false);
    }

    void ResumeGame(){
        unPulsed = true;
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
