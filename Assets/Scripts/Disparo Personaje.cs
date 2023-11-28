using UnityEngine;

public class ControlDeDisparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public float velocidadBala = 10f;
    public float cooldownEntreDisparos = 1f;
    public Animator _animator;

    private float tiempoUltimoDisparo;
    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
  
        if (Input.GetKey(KeyCode.Space) && Time.time > tiempoUltimoDisparo + cooldownEntreDisparos)
        {
            _animator.SetBool("Disparo", true);
            Disparar();
        }
    }
    

    void Disparar()
    {
        
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);

       
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        rbBala.velocity = new Vector2(velocidadBala, 0f);

      
        tiempoUltimoDisparo = Time.time;

        //_animator.SetBool("Disparo", false);
    }




    void OnBecameInvisible()
    {
        
        Destroy(gameObject);
    }
}

