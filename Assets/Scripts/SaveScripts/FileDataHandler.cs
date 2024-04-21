using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName){
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    // Method to get the full save file path
    public string GetSaveFilePath()
    {
        return Path.Combine(dataDirPath, dataFileName);
    }

    public SaveData Load(){
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        SaveData loadedData = null;
        if(File.Exists(fullPath)){

            try{
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open)){
                    using(StreamReader reader = new StreamReader(stream)){
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<SaveData>(dataToLoad);

            }

            catch(Exception e){
                Debug.LogError("Save error at " + fullPath + "/n" + e);
            }
        }
        //Debug.Log(dataDirPath);
        return loadedData;
    }

    public void Save(SaveData data){
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try{
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(data, true);

            using(FileStream stream = new FileStream(fullPath, FileMode.Create)){
                using(StreamWriter writer = new StreamWriter(stream)){
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e){
            Debug.LogError("Save error at " + fullPath + "/n" + e);
        }
    }
}
