using UnityEngine;
using UnityEngine.SceneManagement;

public class DañoPersonaje : MonoBehaviour
{
    private Rigidbody2D rb; // Componente Rigidbody2D del personaje
    private Vector3 origin;
    //public AudioClip sonidoDaño; // Asigna el clip de audio en el Inspector
    //private AudioSource audioSource;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origin = transform.position;

        // Inicializa el componente AudioSource
        //audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.clip = sonidoDaño;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Reproduce el sonido de daño
            //audioSource.PlayOneShot(sonidoDaño);


        }

    }
}