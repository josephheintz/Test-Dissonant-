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

    public void NewGame(){
        SceneManager.LoadScene(4);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
