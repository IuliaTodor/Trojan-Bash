using UnityEngine;

public class MocimientoBala : MonoBehaviour
{
    public float velocidad = 5.0f;
    private Vector3 startPosition;
    private Camera mainCamera;
    void Start()
    {
        startPosition = transform.position;
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        if (!IsVisible())
        {
            Respawn();
        }
    }

    bool IsVisible()
    {
        // Comprueba si la bala está dentro de la vista de la cámara.
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x > 0 && viewportPosition.x < 1;
    }

    void Respawn()
    {
        // Reposiciona la bala en la posición inicial.
        transform.position = startPosition;
    }
}

