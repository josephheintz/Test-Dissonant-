using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.IO;


public class PersistenceDataManager : MonoBehaviour
{

    [Header("File Storage Config")]

    [SerializeField] private string fileName;

    public static PersistenceDataManager instance {get; private set;}

    private SaveData gameData;

    public List<IDataPersistence> dataPersistenceObjects;
    public FileDataHandler dataHandler;

    private void Awake(){
        if(instance != null) Debug.LogError("There are to many Persistence Data Managers.");
        instance = this;
    }

    private void Start(){
        Set();
    }

    private void Set(){
        if(this.dataHandler == null){
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        }
    }

    public bool IsSave(){
    Set();
    Debug.Log(dataHandler);
        if (File.Exists(dataHandler.GetSaveFilePath()))
        {
            return true;
        }
        return false;
    }

    public void NewGame(){

        // Delete previous save file if it exists
        if (File.Exists(dataHandler.GetSaveFilePath()))
        {
            //Debug.Log(dataHandler.GetSaveFilePath());
            File.Delete(dataHandler.GetSaveFilePath());
            LoadGame();
        }
        this.gameData = new SaveData();
    }

    public void SaveGame(){
            foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
                dataPersistenceObj.SaveData(ref gameData);
            }

        dataHandler.Save(gameData);
    }

    public void LoadGame(){
        this.gameData = dataHandler.Load();
        //Debug.Log("Here");

        if(this.gameData == null){
            //Debug.Log("No saved data, using starting new game");
            if (gameData == null) NewGame();
        }

        // push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {

        //IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
        //    .OfType<IDataPersistence>();

        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
