using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [DoNotSerialize] public int bytes;
    [DoNotSerialize] public PowerUp[] powerUps;

    public bool SeDesbloqueo;
    public bool SeDesbloqueo1;

    public int dieEnemy = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        bytes = 2000;

        powerUps = new PowerUp[DataManager.instance.gameData.powerUps.Length];

        for (int i = 0; i < DataManager.instance.gameData.powerUps.Length; i++)
        {
            powerUps[i] = DataManager.instance.gameData.powerUps[i];
            Debug.Log("el pepe");
        }
        Debug.Log(powerUps.Length);
        Debug.Log(DataManager.instance.gameData.powerUps.Length);
        if (DataManager.instance.gameData.powerUps.Length > 0 || GameManager.Instance.powerUps.Length > 0)
        {
            Debug.Log(DataManager.instance.gameData.powerUps[0]);
            Debug.Log(powerUps[0]);
        }


        dieEnemy = 0;
    }

    private void Update()
    {
        Debug.Log("Enemigo muerto" + dieEnemy);
    }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}