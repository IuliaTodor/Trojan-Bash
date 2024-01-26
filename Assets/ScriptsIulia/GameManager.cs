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
        


        dieEnemy = 0;
    }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}