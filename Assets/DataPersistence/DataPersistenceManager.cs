using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Unity.IO.LowLevel.Unsafe;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] 
    private string fileName;
    public DataHandler dataHandle;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    public static DataPersistenceManager instance { get; private set; }


    private void Start()
    {
        //Application.persistentDataPath -> project path
        this.dataHandle = new DataHandler(Application.persistentDataPath,fileName);
        this.dataPersistenceObjects = findAllDataPersistenceObjects();
        LoadGame();
    }

    private List<IDataPersistence> findAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    void OnApplicationQuit()
    {
        
        //SaveGame();
    }
    

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene");

        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    
    public void LoadGame()
    {
        this.gameData = dataHandle.Load();
        //Todo - Load game data from file using data handler
        //If there is no game data -> newGame
        if(this.gameData == null)
        {
            Debug.Log("There is no game data being saved => NewGame()");
            NewGame();
        }
        foreach(IDataPersistence dataPersistence in this.dataPersistenceObjects)
        {
            dataPersistence.LoadData(gameData);
        }
        
        //Todo - Push all saved data to other scripts
        Debug.Log("Loaded Lives = "+gameData.lives);
    }
    
    public void SaveGame()
    {
        //Pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistence in this.dataPersistenceObjects)
        {
            dataPersistence.SaveData(ref gameData);
        }
        Debug.Log("Saved Lives = "+ gameData.lives);
        Debug.Log("Saved Currency = "+ gameData.currency);
        Debug.Log("Saved Tower = "+ gameData.TowerList);
        Debug.Log("Saved Wave = "+ gameData.waveEnemy);
        
        //Save the data to a file using data handler
        dataHandle.Save(gameData);
    }

}
