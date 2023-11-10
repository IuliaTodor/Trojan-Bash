using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public Camera mainCamera; // Asigna la cámara principal desde el Inspector.
    private bool gameStarted = false; // Variable para rastrear si el juego ha comenzado.
    private string sceneToRestart;
    // Start is called before the first frame update
    public void DesplegarMenu()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
