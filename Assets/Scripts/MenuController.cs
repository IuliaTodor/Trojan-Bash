using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    //public Camera mainCamera; // Asigna la c�mara principal desde el Inspector.
    public static MenuController instance;
    private void Awake()
    {
        DataManager.instance.LoadData();
    }

    private void Start()
    {
        Debug.Log(GameManager.Instance.bytes);
    }
    private void Update()
    {
        Debug.Log("Dentro del men�: " + GameManager.Instance.bytes);
    }

    public void StartGame()
    {
        AudioManager.instance.StopPlaying("MusicMenu");
        AudioManager.instance.ChoosePlay("MusicGame", 1);
        GameManager.Instance.SceneChange("MainScene");
    }

    public void Settings()
    {
        AudioManager.instance.ChoosePlay("TestEfect", 0);
        GameManager.Instance.SceneChange("Settings");
    }

    public void Tienda()
    {
        DataManager.instance.LoadData();
        GameManager.Instance.SceneChange("Shop");
    }
    public void ExitGame()
    {
        Application.Quit();

    }

    public void MainMenu()
    {
        AudioManager.instance.StopPlaying("MusicGame");
        AudioManager.instance.ChoosePlay("MusicMenu", 1);
        DataManager.instance.SaveData();
        Debug.Log("Guardado");
        SceneManager.LoadScene("MainMenu");
    }

    public void Achievements()
    {
        SceneManager.LoadScene("Achievements");
    }
}