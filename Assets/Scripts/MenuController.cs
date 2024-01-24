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
        GameManager.Instance.SceneChange("MainScene");
    }

    public void Settings()
    {
        AudioManager.instance.ChoosePlay("TestEfect", 0);
        GameManager.instance.SceneChange("Settings");
    }

    public void Tienda()
    {
        DataManager.instance.LoadData();
        GameManager.instance.SceneChange("Shop");
    }
    public void ExitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            Application.Quit();
        }
    }

    public void MainMenu()
    {
        DataManager.instance.SaveData();
        SceneManager.LoadScene("MainMenu");
    }

    public void Achievements()
    {
        SceneManager.LoadScene("Achievements");
    }
}