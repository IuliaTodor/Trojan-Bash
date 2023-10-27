using UnityEngine;

public class BalaRalentizadora : MonoBehaviour
{
  
    public float ralentizacionFactor = 0.5f; // Factor de ralentizaci�n

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("caballo"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
               
                rb.velocity *= ralentizacionFactor;
            }
        }

        // Destruye la bala despu�s de la colisi�n
        Destroy(gameObject);
    }
}