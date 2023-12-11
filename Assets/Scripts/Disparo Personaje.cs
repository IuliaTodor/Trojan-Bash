using UnityEngine;

public class ControlDeDisparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public float velocidadBala = 10f;
    public float cooldownEntreDisparos = 1f;
    public float timeWAait = 111;

    private Animator _an;

    private float tiempoUltimoDisparo;

    private void Start()
    {
        _an = GetComponentInParent<Animator>();
    }

    void Update()
    {
  
        if (Input.GetKey(KeyCode.Space) && Time.time > tiempoUltimoDisparo + cooldownEntreDisparos)
        {
            Disparar();
            _an.SetBool("Disparo", true);
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

