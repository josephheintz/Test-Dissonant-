using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static bool spawned = false;
    [SerializeField] public Object Player;
    [SerializeField] public Object Managers;
    [SerializeField] public Object Inventory;
    [SerializeField] public Object Camera;

    void Awake()
    {
        if(spawned == false){
            spawned = true;
            DontDestroyOnLoad(Player);
            DontDestroyOnLoad(Managers);
            DontDestroyOnLoad(Camera);
        } else {
            Destroy(Player);
            Destroy(Managers);
            Destroy(Camera);
        }
    }
}
