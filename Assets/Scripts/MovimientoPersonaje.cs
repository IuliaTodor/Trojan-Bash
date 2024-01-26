using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private Animator _animator;
    public float velocidadMovimiento = 8.0f;
    public float fuerzaSalto = 20.0f;
    private Rigidbody2D rb;
    private bool enElSuelo;
    private BoxCollider2D boxCollider;
    private PolygonCollider2D polygonCollider;
    public static MovimientoPersonaje instance;

    void Start()
    {
        instance = this;
        _animator = gameObject.GetComponent<Animator>();
        rb = GetComponent < Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        //_animator.SetBool("Moverse", true); 
        Vector2 movimiento = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.velocity.y);
        rb.velocity = movimiento;

        //Salto
        if (Input.GetKeyDown(KeyCode.UpArrow) && enElSuelo)
        {
            _animator.SetBool("Salto", true);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        
        //Agacharse
        if (Input.GetKeyDown(KeyCode.DownArrow) && enElSuelo)
        {
            _animator.SetBool("Agacharse", true);
            boxCollider.enabled = true;
            polygonCollider.enabled = false; 
        }        
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _animator.SetBool("Agacharse", false);
            boxCollider.enabled = false; 
            polygonCollider.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enElSuelo = true;
            _animator.SetBool("Salto", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enElSuelo = false;
            
        }
    }
}