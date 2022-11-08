using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHandler 
{
    private string dataDirPath = "";

    private string dataFileName = "";

    public DataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = System.IO.Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                //Load the serialize from file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //Deserialize Json => GameData
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }catch(Exception ex)
            {
                Debug.LogError("Error when tried to load data to file: " + fullPath + "\n" + ex);
            }
        }
        return loadedData;
    }
    
    public void Save(GameData data)
    {
        string fullPath = System.IO.Path.Combine(dataDirPath, dataFileName);
        try
        {

            //Create Dir for the file that will be written on in case not already been created
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fullPath));
            //Pass gameData => Json
            Debug.Log("DataHandler.Save()");
            foreach (TowerEnum t in data.TowerList)
            {
                Debug.Log("x: " + t.position.x + " | y: " + t.position.y);
                Debug.Log("ID: " + t.id);
            }
            string dataToStore = JsonUtility.ToJson(data,true);
            Debug.Log("dataToStore: " + dataToStore);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
            Debug.Log("Saved Game to " + fullPath); 

        }catch(Exception ex)
        {
            Debug.LogError("Error when tried to save data to file: " + fullPath+"\n"+ex);
        }
    }

}
