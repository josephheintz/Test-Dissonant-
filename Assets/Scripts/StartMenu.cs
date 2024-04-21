using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StartMenu : MonoBehaviour
{

    private GameObject managers;
    [SerializeField] public GameObject loadButton;

    private void Start(){
        managers = GameObject.FindGameObjectWithTag("GameController");
        Debug.Log(managers);
        if (managers.GetComponent<PersistenceDataManager>().IsSave())
        {
            loadButton.SetActive(true);
        } else {
            loadButton.SetActive(false);
        }
        PersistenceDataManager.instance.LoadGame();
    }

    public void NewGame(){
        //SceneManager.LoadScene(4);
        PersistenceDataManager.instance.NewGame();
        SceneManager.LoadScene(0);
    }

    public void LoudGame(){
        //SceneManager.LoadScene(4);
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
