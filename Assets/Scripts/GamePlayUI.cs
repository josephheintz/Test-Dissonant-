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
    private GameObject playerPrefab; // Prefab of the player object


    void Start(){
        healthText = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        menu.SetActive(false);

        SetButtons();
    }

    void SetButtons(){
        Transform Fant2 = transform.Find("NexesTeleportScreen/FantButtons/Button (Legacy) (1)");
        Transform Fant3 = transform.Find("NexesTeleportScreen/FantButtons/Button (Legacy) (2)");
        Transform Fant4 = transform.Find("NexesTeleportScreen/FantButtons/Button (Legacy) (3)");

        Transform Sci2 = transform.Find("NexesTeleportScreen/SciButtons/Button (Legacy) (4)");
        Transform Sci3 = transform.Find("NexesTeleportScreen/SciButtons/Button (Legacy) (5)");
        Transform Sci4 = transform.Find("NexesTeleportScreen/SciButtons/Button (Legacy) (6)");

        Transform Oce2 = transform.Find("NexesTeleportScreen/OceButtons/Button (Legacy) (1)");
        Transform Oce3 = transform.Find("NexesTeleportScreen/OceButtons/Button (Legacy) (2)");
        Transform Oce4 = transform.Find("NexesTeleportScreen/OceButtons/Button (Legacy) (3)");

        Transform Hell2 = transform.Find("NexesTeleportScreen/HellButtons/Button (Legacy) (1)");
        Transform Hell3 = transform.Find("NexesTeleportScreen/HellButtons/Button (Legacy) (2)");
        Transform Hell4 = transform.Find("NexesTeleportScreen/HellButtons/Button (Legacy) (3)");

        Fant2.gameObject.SetActive(false);
        Fant3.gameObject.SetActive(false);
        Fant4.gameObject.SetActive(false);

        Sci2.gameObject.SetActive(false);
        Sci3.gameObject.SetActive(false);
        Sci4.gameObject.SetActive(false);

        Oce2.gameObject.SetActive(false);
        Oce3.gameObject.SetActive(false);
        Oce4.gameObject.SetActive(false);

        Hell2.gameObject.SetActive(false);
        Hell3.gameObject.SetActive(false);
        Hell4.gameObject.SetActive(false);
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
