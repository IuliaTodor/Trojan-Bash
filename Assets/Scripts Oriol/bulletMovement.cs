using UnityEngine;

public class BulletMovement : MonoBehaviour
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

    }

    void Respawn()
    {
        // Reposiciona la bala en la posición inicial.
        transform.position = startPosition;
    }
}

