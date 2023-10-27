using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasP : MonoBehaviour
{
    public int vidas;
    public GameObject ultimaColl;
    // Start is called before the first frame update
    void Start()
    {
        vidas = 3;
        ultimaColl = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ficheros y Archivos Daño 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy") 
        {
            vidas -= 1;
        }
        if (collision.transform.tag == "MainCamera")
        {
            vidas -= 1;
            ultimaColl = collision.gameObject;
        }
        //Si el jugador se encuentra atrapado entre la camara y un obstáculo a
        //los obstaculos se les quita el box collider
        if (ultimaColl.tag == "MainCamera" && collision.transform.tag == "Enemy") 
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var obj in list)
            {
                obj.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    //No fuera de pantalla
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MainCamera")
        {
            ultimaColl = null;
        }
    }

    //Disparos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            vidas -= 1;
        }
    }
}
