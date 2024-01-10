using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class VidasP : MonoBehaviour
{
    public static event Action<Color> ChangeColor = delegate { };
    public int vidas;
    public string ultimaColl;
    public Animator animator;
    public int iFrames;
    private int framesInvencivilidad;
    private Dead dead;
    public static VidasP vid;
    // Start is called before the first frame update 
    void Start()
    {
        vidas = 3;
        ultimaColl = null;
        animator = GetComponent<Animator>();
        framesInvencivilidad = 0;
        dead = GetComponent<Dead>();
    }

    // Update is called once per frame 
    void Update()
    {
        animator.SetInteger("Vidas", vidas);
        if (framesInvencivilidad != 0)
        {
            framesInvencivilidad--;
            animator.SetInteger("IFrames", framesInvencivilidad);
        }
        if (vidas == 0)
        {
            dead.Disenable();
        }
    }

    //Ficheros y Archivos Dato  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (framesInvencivilidad == 0)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Hurt();
                Debug.Log("A");
            }
            if (collision.gameObject.CompareTag("MainCamera"))
            {
                Hurt();
                ultimaColl = collision.transform.tag;
            }
            //Si el jugador se encuentra atrapado entre la camara y un obstaculo a 
            //los obstaculos se les quita el box collider 
            if (ultimaColl == "MainCamera" && collision.gameObject.CompareTag("Enemy"))
            {
                GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var obj in list)
                {
                    obj.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
    //Disparos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (framesInvencivilidad == 0)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Hurt();
            }
        }
    }
    private void Hurt()
    {
        vidas -= 1;
        framesInvencivilidad = iFrames;
        animator.SetInteger("IFrames", framesInvencivilidad);
        switch (vidas)
        {
            case 0:
                SceneManager.LoadScene("GameOver");
                break;
            case 1:
                ChangeColor.Invoke(Color.red);
                //VidasFeedback.instance.ShowLifesFeedback(Color.red);
                break; 
            case 2:
                ChangeColor.Invoke(new Color(1f, 0.5938594f,0f));
                //VidasFeedback.instance.ShowLifesFeedback(Color.yellow);
                break; 
        }
    }


    
}
