using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private Text popUpText; // Change this to Text type
    private string interactionButton = "Interact"; // Name of the input button
    private bool playerInsideTrigger = false; // Track if player is inside trigger
    private GameObject UIManager;

    [SerializeField] public event Action<GameObject> OnInteract1; // Event for interaction
    [SerializeField] public event Action<GameObject> OnInteract2; // Event for interaction

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
        // Check if the player is pressing the first interaction button
        if (Input.GetAxisRaw(interactionButton) < 0) // active when "e" is pressed
        {
            // Invoke the interaction event with this game object
            OnInteract1?.Invoke(gameObject);
        }

        // Check if the player is pressing the second interaction button
        if (Input.GetAxisRaw(interactionButton) > 0) // active when "e" is pressed
        {
            // Invoke the interaction event with this game object
            OnInteract2?.Invoke(gameObject);
        }

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
            else
                Debug.LogError("PopUpText reference is not set in the inspector!");
        }
    }
}
