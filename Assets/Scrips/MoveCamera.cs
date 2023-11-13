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
    public GameObject score;
    private float multiplicador;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Transform>();
        score = GameObject.Find("ControladorPuntos"); //Objeto con el script "ScoreManager.sc"
        multiplicador = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position += new Vector3(velocidad, 0f, 0f);
        cuenta++;
        if (cuenta == tiempo)
        {
            velocidad += aceleracion;

            cuenta = 0;
            tiempo--;
        }
        if (cuenta % 50 == 0)// Cada 50 frames sube la puntuacion

        {
            score.GetComponent<ScoreManager>().RaiseScore(Mathf.RoundToInt(1f * multiplicador));
            multiplicador += 0.1f;
            Debug.Log(multiplicador);
        }
    }
}
