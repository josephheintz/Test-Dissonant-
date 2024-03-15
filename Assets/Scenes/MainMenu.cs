using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

public void PlayGame(){
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}

public void GoToSettingsMenu(){
	SceneManager.LoadScene("SettingsMenu");
}

public void GoToMainMenu(){
	SceneManager.LoadScene("MainMenu");
}

public void QuitGame(){
	Application.Quit();
}
}
