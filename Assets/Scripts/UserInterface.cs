using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Camera mainCamera; // Asigna la cámara principal desde el Inspector.
    private bool gameStarted = false; // Variable para rastrear si el juego ha comenzado.
    private string sceneToRestart;
    public void StartGame()
    {
        GameManager.instance.SceneChange("EscenaFinal");
    }
    public void Tienda()
    {
        gameObject.SetActive(true);
    }
    public void ExitGame()
    {
        // Sal del juego al modo de edición.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}