using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    [SerializeField] public bool[] teleporterList;
    public int[] playerResources;

    public SaveData()
    {
        playerResources = new int[8];
        teleporterList = new bool[21];
    }
}
