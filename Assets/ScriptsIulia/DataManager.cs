using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
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

            gameData.sliderMusicValue = loadedData.sliderMusicValue;
            gameData.sliderSFXValue = loadedData.sliderSFXValue;

            gameData.logroPuntos = loadedData.logroPuntos;
            gameData.logroMatar = loadedData.logroMatar;

            //_____________________________________________________________

            GameManager.Instance.bytes = gameData.bytes;



            StartCoroutine(LoadSound());
            StartCoroutine(LoadAchievements());
            StartCoroutine(LoadInventoryData());
            
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

                for (int i = 0; i < InventoryUI.instance.slots.Count; i++)
                {
                    newData.images.Add(InventoryUI.instance.slots[i].icon.sprite);
                    newData.images[i] = InventoryUI.instance.slots[i].icon.sprite;
                }
            }

            if (TestSlider.instance != null)
            {
                newData.sliderMusicValue = TestSlider.instance.musicSlider.value;
                newData.sliderSFXValue = TestSlider.instance.efectSlider.value;
            }

            if(TestSlider.instance == null)
            {
                newData.sliderMusicValue = 0.5f;
                newData.sliderSFXValue = 0.5f;
            }

            newData.logroPuntos = GameManager.Instance.SeDesbloqueo;
            newData.logroMatar = GameManager.Instance.SeDesbloqueo1;

        };

        string JsonString = JsonUtility.ToJson(newData);

        File.WriteAllText(SaveFiles, JsonString);

        Debug.Log("Saved File");
    }

    IEnumerator LoadInventoryData()
    {
        while (Inventory.instance == null)
        {
            yield return null;
        }

        if(gameData.powerUps.Length != 0)
        {
            Inventory.instance.powerUps = gameData.powerUps;
        }

        if (InventoryUI.instance != null)
        {
            for (int i = 0; i < InventoryUI.instance.slots.Count; i++)
            {
                if (InventoryUI.instance.slots[i] != null)
                {
                    PowerUp currentPowerUp = Inventory.instance.powerUps[i];

                    if (currentPowerUp != null)
                    {
                        InventoryUI.instance.slots[i].UpdateSlotUI(currentPowerUp);
                    }
                }
            }
        }
    }

    IEnumerator LoadSound()
    {
        if (TestSlider.instance != null)
        {
            TestSlider.instance.musicSlider.value = gameData.sliderMusicValue;
            TestSlider.instance.efectSlider.value = gameData.sliderSFXValue;
        }


        yield return true;
    }

    IEnumerator LoadAchievements()
    {
            GameManager.Instance.SeDesbloqueo = gameData.logroPuntos;
            GameManager.Instance.SeDesbloqueo1 = gameData.logroMatar;

        yield return true;
    }


}
