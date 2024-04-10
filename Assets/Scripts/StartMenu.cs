using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void NewGame(){
        SceneManager.LoadScene(4);
    }

    void QuitGame(){
        Application.Quit(); // lets the player quit the game DOSE NOT WORK FROM THE EDITOR
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
