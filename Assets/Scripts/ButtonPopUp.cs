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

    // Start is called before the first frame update
    private void Start()
    {
        if (popUpText != null)
            popUpText.gameObject.SetActive(false);
        else
            Debug.LogError("PopUpText reference is not set in the inspector!");
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        // Check if the player is pressing the interaction button
        if (Input.GetButtonDown(interactionButton) == true) // active when "e" is pressed
        {
            if(selectEffect == 0) Debug.Log("Hello, how are you?"); // default, says hi on the log
            if(selectEffect == 1) gameObject.GetComponent<ReturnJump>().enabled = true; // uses the return jump
            // Can add here
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detect player tag on player
        if (other.CompareTag("Player"))
        {
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
            //Debug.LogError("PopUpText reference is not set in the inspector!");
            if (popUpText != null){
                popUpText.gameObject.SetActive(false);
                }
        }
    }
}
