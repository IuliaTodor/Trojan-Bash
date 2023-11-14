using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveCamera : MonoBehaviour
{
    public float velocidad;
    public float aceleracion;
    public int tiempo;
    private Transform rb;
    private int cuenta;
    private float multiplicador;
    public GameObject controlador;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Transform>();
        multiplicador = 1f;
        controlador = GameObject.Find("ControladorPuntos");// poner el nobre del objeto que tenga el script "ScoreManager.cs"
        scoreManager = controlador.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position += new Vector3(velocidad, 0f, 0f);
        cuenta++;
        if (cuenta >= tiempo) // Cada vez que pasen x frames aumenta la velocidad "cuenta son los frames que han pasado i tiempo es a lo que tiene que llegar" 
        {
            velocidad += aceleracion;

            cuenta = 0;
            tiempo--;
        }
        if (cuenta % 50 == 0)// Cada 50 frames sube la puntuacion
        {
            scoreManager.RaiseScore(Mathf.RoundToInt(1f * multiplicador));
            multiplicador += 0.1f;
        }
        Debug.Log(cuenta);
    }
}
