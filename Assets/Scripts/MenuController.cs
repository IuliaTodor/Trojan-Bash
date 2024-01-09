using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    //public Camera mainCamera; // Asigna la c�mara principal desde el Inspector.
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
        GameManager.instance.SceneChange("MainMenu");
    }
}