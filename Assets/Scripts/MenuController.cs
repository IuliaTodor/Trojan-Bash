using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    //public Camera mainCamera; // Asigna la c�mara principal desde el Inspector.
    public static MenuController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        DataManager.instance.LoadData();
    }

    private void Start()
    {
        Debug.Log(GameManager.instance.bytes);
    }
    private void Update()
    {
        Debug.Log("Dentro del men�: " + GameManager.instance.bytes);
    }

    public void StartGame()
    {
        GameManager.instance.SceneChange("MainScene");
    }

    public void Settings()
    {
        GameManager.instance.SceneChange("Settings");
    }

    public void Tienda()
    {
        DataManager.instance.LoadData();
        GameManager.instance.SceneChange("Shop");
    }
    public void ExitGame()
    {
        if(UnityEditor.EditorApplication.isPlaying)
        {
            Application.Quit();
        }
    }

    public void MainMenu()
    {
        DataManager.instance.SaveData();
        SceneManager.LoadScene("MainMenu");
    }
}