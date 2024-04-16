using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeleportTracker : MonoBehaviour, IDataPersistence
{
    public int hi = 0;
    public bool[] telea;


    private void Awake(){
        //hello = hi;
    }

    public void LoadData(SaveData data){
        this.hi = data.hi;
        for (int i = 0; i < telea.Length; i++) this.telea[i] = data.teleporterList[i];

    }
    public void SaveData(ref SaveData data){
        data.hi = this.hi;
        for (int i = 0; i < telea.Length; i++) data.teleporterList[i] = this.telea[i];
    }
}
