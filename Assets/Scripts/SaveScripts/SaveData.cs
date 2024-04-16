using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    [SerializeField] public bool[] teleporterList;
    public int hi;

    public SaveData()
    {
        this.hi = 0;
        teleporterList = new bool[21];
    }
}
