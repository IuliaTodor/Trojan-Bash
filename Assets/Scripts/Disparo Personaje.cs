using UnityEngine;

public class ControlDeDisparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public float velocidadBala = 10f;
    public float cooldownEntreDisparos = 1f;

    private float tiempoUltimoDisparo;

    void Update()
    {
  
        if (Input.GetKey(KeyCode.Space) && Time.time > tiempoUltimoDisparo + cooldownEntreDisparos)
        {
            Disparar();
        }
        
    }
    

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);

       
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        rbBala.velocity = new Vector2(velocidadBala, 0f);

      
        tiempoUltimoDisparo = Time.time;
    }
   

    
    void OnBecameInvisible()
    {
        
        Destroy(gameObject);
    }
}

