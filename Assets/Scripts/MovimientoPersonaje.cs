using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 8.0f;
    public float fuerzaSalto = 20.0f;
    private Rigidbody2D rb;
    private bool enElSuelo;
    private BoxCollider2D boxCollider;
    private PolygonCollider2D polygonCollider;

    void Start()
    {
        rb = GetComponent < Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {

        float movimientoHorizontal = Input.GetAxis("Horizontal");

        Vector2 movimiento = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.velocity.y);
        rb.velocity = movimiento;

        
        if (Input.GetKeyDown(KeyCode.UpArrow) && enElSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && enElSuelo)
        {
            boxCollider.enabled = true;
            polygonCollider.enabled = false; 
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            boxCollider.enabled = false; 
            polygonCollider.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enElSuelo = true;
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