using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeleportTracker : MonoBehaviour, IDataPersistence
{
    public bool[] telea;
    public bool[] bosses;

    public void LoadData(SaveData data){
        for (int i = 0; i < telea.Length; i++) this.telea[i] = data.teleporterList[i];
        for (int i = 0; i < bosses.Length; i++) this.bosses[i] = data.bossList[i];
    }

    public void SaveData(ref SaveData data){
        for (int i = 0; i < telea.Length; i++) data.teleporterList[i] = this.telea[i];
        for (int i = 0; i < bosses.Length; i++) data.bossList[i] = this.bosses[i];
    }
}
