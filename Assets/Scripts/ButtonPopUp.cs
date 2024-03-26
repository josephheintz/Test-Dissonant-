using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPopUp : MonoBehaviour
{
    [SerializeField] private Text popUpText; // Change this to Text type
    [SerializeField] private int selectEffect = 0; // Name of the input button
    private string interactionButton = "Interact"; // Name of the input button
    private bool playerInsideTrigger = false; // Track if player is inside trigger
    private GameObject UIManager;

    // Start is called before the first frame update
    private void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UIManager");
        if (popUpText != null)
            popUpText.gameObject.SetActive(false);
        else
            Debug.LogError("PopUpText reference is not set in the inspector!");
    }

    void Update()
    {
        if (playerInsideTrigger) // Only get input if player is inside trigger
        {
            GetInput();
        }
    }

    void GetInput()
    {
        // Check if the player is pressing the interaction button
        if (Input.GetAxisRaw(interactionButton) < 0) // active when "e" is pressed
        {
            if(selectEffect == 0) Debug.Log("Hello, how are you?"); // default, says hi on the log
            if(selectEffect == 1) gameObject.GetComponent<ReturnJump>().enabled = true; // uses the return jump
            //if(selectEffect == 2) gameObject.GetComponent<NexisTeleport>().enabled = true; // uses the nexis jump
            if(selectEffect == 2) teleportMenu(); // uses the nexis jump
            if(selectEffect == 3) Debug.Log("What will this be?"); // replace with other interact
            if(selectEffect == 4) Debug.Log("What will this be?"); // replace with other interact
            // Can add here
        } else if(Input.GetAxisRaw(interactionButton) > 0){

        }
    }

    private void teleportMenu(){
        UIManager.GetComponent<GamePlayUI>().nexOn = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detect player tag on player
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true; // Player is inside trigger
            if (popUpText != null)
                popUpText.gameObject.SetActive(true);
            else
                Debug.LogError("PopUpText reference is not set in the inspector!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Detect player leaving trigger area

        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false; // Player is not inside trigger
            if (popUpText != null)
                popUpText.gameObject.SetActive(false);
                UIManager.GetComponent<GamePlayUI>().nexOn = false;
            } else {
                Debug.LogError("PopUpText reference is not set in the inspector!");
            }
    }
}
