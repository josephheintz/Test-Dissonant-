using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI to use Text compone
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    private GameObject player; // Prefab of the player object
    [SerializeField]  private GameObject menu; // Prefab of the player object
    [SerializeField]  private GameObject nexMenu; // Prefab of the player object

    private Text healthText;
    private bool isPulsed = false;
    private bool unPulsed = false;
    public bool nexOn = false;
    //private GameObject playerPrefab; // Prefab of the player object
    private GameObject levelManager; // Prefab of the player object
    public Transform[] buttons;


    void Start(){
        healthText = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        menu.SetActive(false);

        SetButtons();
    }

    void SetButtons(){

        buttons[0] =  null;

        buttons[1] =  transform.Find("NexesTeleportScreen/FantButtons/Button (Legacy) (1)");
        buttons[2] =  transform.Find("NexesTeleportScreen/FantButtons/Button (Legacy) (2)");
        buttons[3] =  transform.Find("NexesTeleportScreen/FantButtons/Button (Legacy) (3)");

        buttons[4] =  transform.Find("NexesTeleportScreen/SciButtons/Button (Legacy) (4)");
        buttons[5] =  transform.Find("NexesTeleportScreen/SciButtons/Button (Legacy) (5)");
        buttons[6] =  transform.Find("NexesTeleportScreen/SciButtons/Button (Legacy) (6)");

        buttons[7] =  transform.Find("NexesTeleportScreen/OceButtons/Button (Legacy) (1)");
        buttons[8] =  transform.Find("NexesTeleportScreen/OceButtons/Button (Legacy) (2)");
        buttons[9] =  transform.Find("NexesTeleportScreen/OceButtons/Button (Legacy) (3)");

        buttons[10] =  transform.Find("NexesTeleportScreen/HellButtons/Button (Legacy) (1)");
        buttons[11] =  transform.Find("NexesTeleportScreen/HellButtons/Button (Legacy) (2)");
        buttons[12] =  transform.Find("NexesTeleportScreen/HellButtons/Button (Legacy) (3)");



        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
        buttons[3].gameObject.SetActive(false);

        buttons[4].gameObject.SetActive(false);
        buttons[5].gameObject.SetActive(false);
        buttons[6].gameObject.SetActive(false);

        buttons[7].gameObject.SetActive(false);
        buttons[8].gameObject.SetActive(false);
        buttons[9].gameObject.SetActive(false);

        buttons[10].gameObject.SetActive(false);
        buttons[11].gameObject.SetActive(false);
        buttons[12].gameObject.SetActive(false);
    }

    void ResumeGame(){
        unPulsed = true; // lets the player un-pulse the game with menu button
    }

    void ReturnToHub(){
        ReturnJump.Jump();
    }

    void QuitGame(){
        //Application.Quit(); // lets the player quit the game DOSE NOT WORK FROM THE EDITOR
        SceneManager.LoadScene(5);
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-enable the pulse menu GameObject
        menu.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {

    //if (levelManager.GetComponent<TeleportTracker>().telea[1] == true)
    //{
        //buttons[0].gameObject.SetActive(true);
    //}

        nexMenu.SetActive(nexOn);

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
