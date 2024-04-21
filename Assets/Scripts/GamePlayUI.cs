using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI to use Text component
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    private GameObject player; // Reference to the player GameObject
    [SerializeField] private GameObject menu; // Reference to the pause menu GameObject
    [SerializeField] private GameObject nexMenu; // Reference to the nex menu GameObject

    private Text healthText; // Reference to the health text component
    private bool isPulsed = false; // Flag indicating if the game is paused
    private bool unPulsed = false; // Flag indicating if the game is unpaused
    public bool isInMainMenu = false; // Flag indicating if the game is in the main menu
    public bool nexOn = false; // Flag indicating if the nex menu is active
    private GameObject levelManager; // Reference to the LevelManager GameObject
    public Transform[] buttons; // Array to hold references to teleport buttons

    void Start(){
        // Initialize healthText with the Text component of the GameObject
        healthText = GetComponent<Text>();
        // Find the player GameObject using its tag
        player = GameObject.FindGameObjectWithTag("Player");
        // Find the LevelManager GameObject using its tag
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        // Deactivate the pause menu GameObject
        menu.SetActive(false);
        // Initialize the teleport buttons
        SetButtons();
    }

    // Initialize references to teleport buttons
    void SetButtons(){

        // Assign null to the first element of the buttons array
        buttons[0] =  null;
        // Assign null to the elements of the buttons array for the fantasy world
        buttons[1] =  transform.Find("NexesTeleportScreen/FantButtons/Button (Legacy) (1)");
        buttons[2] =  transform.Find("NexesTeleportScreen/FantButtons/Button (Legacy) (2)");
        buttons[3] =  transform.Find("NexesTeleportScreen/FantButtons/Button (Legacy) (3)");
        // Assign null to the elements of the buttons array for the sci-fi world
        buttons[4] =  transform.Find("NexesTeleportScreen/SciButtons/Button (Legacy) (4)");
        buttons[5] =  transform.Find("NexesTeleportScreen/SciButtons/Button (Legacy) (5)");
        buttons[6] =  transform.Find("NexesTeleportScreen/SciButtons/Button (Legacy) (6)");
        // Assign null to the elements of the buttons array for the ocean world
        buttons[7] =  transform.Find("NexesTeleportScreen/OceButtons/Button (Legacy) (1)");
        buttons[8] =  transform.Find("NexesTeleportScreen/OceButtons/Button (Legacy) (2)");
        buttons[9] =  transform.Find("NexesTeleportScreen/OceButtons/Button (Legacy) (3)");
        // Assign null to the elements of the buttons array for the hell world
        buttons[10] =  transform.Find("NexesTeleportScreen/HellButtons/Button (Legacy) (1)");
        buttons[11] =  transform.Find("NexesTeleportScreen/HellButtons/Button (Legacy) (2)");
        buttons[12] =  transform.Find("NexesTeleportScreen/HellButtons/Button (Legacy) (3)");


        // Assign null to the buttons to inactive
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

    // Function to resume the game
    void ResumeGame(){
        unPulsed = true; // Allows the player to unpause the game with the menu button
    }

    // Load a saved game
    public void LoadAGame(){
        PersistenceDataManager.instance.LoadGame(); //go back to last saved data
        ReturnJump.Jump(); // Jump back to the hub scene
    }

    // Return to the hub
    void ReturnToHub(){
        // Code to return to the hub
    }

    // Quit the game
    void QuitGame(){
        SceneManager.LoadScene(7); // Load the main screen scene
    }

    // Called when a scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-enable the pause menu GameObject when a scene is loaded
        menu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Set the active state of the nex menu GameObject based on the value of nexOn
        nexMenu.SetActive(nexOn);

        // Check if the Esc key is pressed to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape) && isPulsed == false)
        {
            Time.timeScale = 0f; // Pause the game
            player.GetComponent<PlayerController>().enabled = false; // Disable player controller
            menu.SetActive(true); // Activate the pause menu
            isPulsed = true; // Set isPulsed flag to true
            unPulsed = false; // Reset unPulsed flag
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && isPulsed == true) || unPulsed == true || isInMainMenu == true)
        {
            Time.timeScale = 1f; // Unpause the game
            player.GetComponent<PlayerController>().enabled = true; // Enable player controller
            isPulsed = false; // Reset isPulsed flag
            menu.SetActive(false); // Deactivate the pause menu
            unPulsed = true; // Set unPulsed flag to true
        }
    }
}
