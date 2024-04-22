using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StartMenu : MonoBehaviour
{

    private GameObject managers;
    private GameObject uiManager;
    [SerializeField] public GameObject loadButton;

    private void Start(){
        managers = GameObject.FindGameObjectWithTag("GameController");
        uiManager = GameObject.FindGameObjectWithTag("UIManager");

        if (managers.GetComponent<PersistenceDataManager>().IsSave())
        {
            loadButton.SetActive(true);
        } else {
            loadButton.SetActive(false);
        }
        PersistenceDataManager.instance.LoadGame();

        uiManager.GetComponent<GamePlayUI>().isInMainMenu = true;
    }

    public void NewGame(){
        uiManager.GetComponent<GamePlayUI>().isInMainMenu = false;
        PersistenceDataManager.instance.NewGame();
        //SceneManager.LoadScene(4);
        ReturnJump.JumpToStart();
    }

    public void LoudGame(){
        uiManager.GetComponent<GamePlayUI>().isInMainMenu = false;
        ReturnJump.Jump();
        PersistenceDataManager.instance.LoadGame();
    }

    public void Credits(){
        SceneManager.LoadScene(6);
    }

    public void QuitGame(){
        Application.Quit(); // lets the player quit the game DOSE NOT WORK FROM THE EDITOR
    }

}
