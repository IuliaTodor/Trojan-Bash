using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string SaveFiles;
    public GameData gameData = new GameData();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SaveFiles = Application.persistentDataPath + "/GameData.json"; //La localización de la carpeta donde están las SaveFiles
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            LoadData();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveData();
        }

    }
    [RuntimeInitializeOnLoadMethod]
    public void LoadData()
    {
        if (File.Exists(SaveFiles))
        {
            string content = File.ReadAllText(SaveFiles);
            Debug.Log("JSON Content: " + content);
            GameData loadedData = JsonUtility.FromJson<GameData>(content);

            //_____________________________________________________________

            gameData.bytes = loadedData.bytes;
            gameData.powerUps = loadedData.powerUps;
            gameData.images = loadedData.images;

            //_____________________________________________________________

            GameManager.instance.bytes = gameData.bytes;

            if (Inventory.instance != null)
            {
                Inventory.instance.powerUps = gameData.powerUps;

                for (int i = 0; i < InventoryUI.instance.slots.Count; i++)
                {
                    if (InventoryUI.instance.slots[i] != null)
                    {
                        Debug.Log("se actualizó unu");
                        Debug.Log("i" + i);
                        Debug.Log("Length " + Inventory.instance.powerUps.Length);
                        InventoryUI.instance.slots[i].UpdateSlotUI(Inventory.instance.powerUps[i]);
                       
                        if (i > Inventory.instance.powerUps.Length)
                        {
                            Debug.Log(i);
                            Debug.Log(Inventory.instance.powerUps.Length);
                            return;
                        }
                    }
                }
            }

            Debug.Log("Inventory Game Data: " + gameData.powerUps);
        }
        else
        {
            Debug.Log("El archivo de guardado no existe");
        }
    }

    public void SaveData()
    {
        GameData newData = new GameData();
        {
            newData.bytes = GameManager.instance.bytes;

            if (Inventory.instance != null)
            {
                newData.powerUps = Inventory.instance.powerUps;
                newData.images = new List<Sprite>();
                

                Debug.Log("Slots count: " + InventoryUI.instance.slots.Count);

                for (int i = 0; i < InventoryUI.instance.slots.Count; i++)
                {
                    Debug.Log("Imagen slot: " + InventoryUI.instance.slots[i].icon.sprite);

                    newData.images.Add(InventoryUI.instance.slots[i].icon.sprite);
                    newData.images[i] = InventoryUI.instance.slots[i].icon.sprite;
                }
            }
        };

        string JsonString = JsonUtility.ToJson(newData);

        File.WriteAllText(SaveFiles, JsonString);

        Debug.Log("Saved File");
    }
}
