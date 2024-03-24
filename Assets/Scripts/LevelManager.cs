using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static bool spawned = false;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Managers;
    [SerializeField] public GameObject Inventory;
    [SerializeField] public GameObject Camera;
    [SerializeField] public GameObject EventSystem;

    void Awake()
    {
        if(spawned == false){
            spawned = true;
            DontDestroyOnLoad(Player);
            DontDestroyOnLoad(Managers);
            DontDestroyOnLoad(Camera);
            DontDestroyOnLoad(EventSystem);
        } else {
            Destroy(Player);
            Destroy(Managers);
            Destroy(Camera);
            Destroy(EventSystem);
        }
    }
}
