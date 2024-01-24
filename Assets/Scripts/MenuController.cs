using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    //public Camera mainCamera; // Asigna la cámara principal desde el Inspector.
    public static MenuController instance;
    private void Awake()
    {
        instance = this;
        DataManager.instance.LoadData();
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