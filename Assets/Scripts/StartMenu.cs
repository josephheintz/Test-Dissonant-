using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void NewGame(){
        SceneManager.LoadScene(4);
    }

    public void LoudGame(){
        SceneManager.LoadScene(4);
        PersistenceDataManager.instance.LoadGame();
    }

    public void Credits(){
        SceneManager.LoadScene(6);
    }

    public void QuitGame(){
        Application.Quit(); // lets the player quit the game DOSE NOT WORK FROM THE EDITOR
    }

}
