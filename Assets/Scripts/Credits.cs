using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void BackToStart()
    {
        SceneManager.LoadScene(6);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene(5);
    }

}
