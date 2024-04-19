using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void NewGame(){
        //SceneManager.LoadScene(4);
        PersistenceDataManager.instance.NewGame();

        // Get the save file path from the FileDataHandler
       /* string saveFilePath = PersistenceDataManager.instance.dataHandler.GetDataHandler().GetSaveFilePath();

        // Delete previous save file if it exists
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }*/

        SceneManager.LoadScene(0);
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
