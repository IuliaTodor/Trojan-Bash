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

    private void SaveData()
    {
        if(File.Exists(SaveFiles))
        {
            string content = File.ReadAllText(SaveFiles);
            gameData = JsonUtility.FromJson<GameData>(content); //Convierte el Json en algo le�ble

            Debug.Log(gameData.bytes);
        }

        else
        {
            Debug.Log("El archivo de guardado no existe");
        }
    }

    private void LoadData()
    {
        GameData gameData = new GameData();
    }


}
