using UnityEngine;
using System.Collections;

public class BalaRalentizadora : MonoBehaviour
{
    public float ralentizacionFactor = 0.5f;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("caballo"))
        {
<<<<<<< HEAD
            Debug.Log("Entra Primera");
=======
>>>>>>> main
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                MovimientoPersonaje movimientoPersonaje = other.GetComponent<MovimientoPersonaje>();
                if (movimientoPersonaje != null)
                {
                    Debug.Log(rb.velocity);
                    
                    movimientoPersonaje.velocidadMovimiento *= ralentizacionFactor;
                    Debug.Log(movimientoPersonaje.velocidadMovimiento);
                    
                    rb.velocity = new Vector2(rb.velocity.x - movimientoPersonaje.velocidadMovimiento, rb.velocity.y);                   
                    Debug.Log(rb.velocity);
                    
                    //new WaitForSeconds(3f);
                    //rb.velocity = new Vector2(rb.velocity.x + movimientoPersonaje.velocidadMovimiento, rb.velocity.y);
                    //Debug.Log(rb.velocity);
                    //// Iniciar una corrutina para esperar 3 segundos y luego restaurar la velocidad original
                    
                }
            }
        }
        // Destruye la bala después de la colisión
        Destroy(gameObject);
    }
}