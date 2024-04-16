using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMenu : MonoBehaviour
{
    private GameObject UIManager;

    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UIManager");
    }
}
