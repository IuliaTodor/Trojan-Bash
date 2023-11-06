using UnityEngine;

public class MocimientoBala : MonoBehaviour
{
    public float velocidad = 5.0f;
    public Vector3 startPosition;
    private Camera mainCamera;
    void Start()
    {
        //hacer que StartPosition sea igual al punto del cursor mano
        startPosition = transform.position;
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        if (!IsVisible())
        {
            Destroy(this.gameObject);
        }
    }

    bool IsVisible()
    {
        // Comprueba si la bala est� dentro de la vista de la c�mara.
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x > 0 && viewportPosition.x < 1;
    }

    void Respawn()
    {
        // Reposiciona la bala en la posici�n inicial.
        transform.position = startPosition;
    }
}

