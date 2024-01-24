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

        SaveFiles = Application.persistentDataPath + "/GameData.json"; //La localizaci�n de la carpeta donde est�n las SaveFiles
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

            GameManager.Instance.bytes = gameData.bytes;

            if (Inventory.instance != null)
            {
                Inventory.instance.powerUps = gameData.powerUps;
                if (InventoryUI.instance != null)
                {
                    for (int i = 0; i < InventoryUI.instance.slots.Count; i++)
                    {
                        if (InventoryUI.instance.slots[i] != null)
                        {
                            Debug.Log("se actualiz� unu");
                            Debug.Log("i" + i);
                            Debug.Log("Length " + Inventory.instance.powerUps.Length);

                            //Usa el PowerUp Actual como �ndice para saber cuantos elementos del array PowerUps tienen scriptable object asignado
                            PowerUp currentPowerUp = Inventory.instance.powerUps[i];

                            if (currentPowerUp != null)
                            {
                                Debug.Log("se actualiz� unu");
                                Debug.Log("i" + i);
                                Debug.Log("PowerUp: " + currentPowerUp); // You can access properties of the current power-up here

                                // Now, use the i variable as needed, knowing that it corresponds to a slot with a power-up
                                InventoryUI.instance.slots[i].UpdateSlotUI(currentPowerUp);
                            }
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
            newData.bytes = GameManager.Instance.bytes;

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
