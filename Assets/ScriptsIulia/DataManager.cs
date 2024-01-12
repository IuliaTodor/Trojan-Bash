using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public GameObject player;
    public string SaveFiles;
    public GameData gameData = new GameData();

    private void Awake()
    {
        SaveFiles = Application.dataPath + "/GameData.json"; //La localizaci�n de la carpeta donde est�n las SaveFiles

        player = GameObject.FindGameObjectWithTag("caballo");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            LoadData();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveData();
        }

    }

    private void LoadData()
    {
        if(File.Exists(SaveFiles))
        {
            string content = File.ReadAllText(SaveFiles);
            Debug.Log(content);
            GameData gameData2 = JsonUtility.FromJson<GameData>(content); //Convierte el Json en algo le�ble
            
            gameData.bytes = gameData2.bytes;
            Debug.Log("Game data bytes " + gameData.bytes);
        }

        else
        {
            Debug.Log("El archivo de guardado no existe");
        }
    }

    private void SaveData()
    {
        GameData newData = new GameData();
        {
          newData.bytes = GameManager.instance.bytes;
        };

        string JsonString = JsonUtility.ToJson(newData);

        File.WriteAllText(SaveFiles, JsonString);

        Debug.Log("Saved File");
  
    }


}
