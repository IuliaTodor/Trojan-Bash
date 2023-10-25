using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Camera mainCamera; // Asigna la cámara principal desde el Inspector.
    private bool gameStarted = false; // Variable para rastrear si el juego ha comenzado.
    private string sceneToRestart;
    public void StartGame()
    {
        if (!gameStarted)
        {
 
            gameObject.SetActive(false);

            // Activa la cámara principal para enfocarse en la escena de juego.
            if (mainCamera != null)
            {
                mainCamera.enabled = true;
            }

            // Marca el juego como iniciado para evitar volver a mostrar el canvas.
            gameStarted = true;
        }
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