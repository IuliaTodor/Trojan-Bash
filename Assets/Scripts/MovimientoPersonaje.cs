using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float fuerzaSalto = 20.0f;
    private Rigidbody2D rb;
    private bool enElSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener la entrada del teclado para moverse
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Aplicar movimiento horizontal
        Vector2 movimiento = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.velocity.y);
        rb.velocity = movimiento;

        // Detectar si el personaje est� en el suelo
        

        // Saltar cuando se presiona la tecla de flecha arriba
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (rb.velocity.y < 0)
            {
                rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            } 
        }
    }
}