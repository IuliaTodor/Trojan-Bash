using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    //public Camera mainCamera; // Asigna la cámara principal desde el Inspector.
    public void StartGame()
    {
        GameManager.instance.SceneChange("MainScene");
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
}