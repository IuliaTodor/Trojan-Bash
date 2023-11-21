using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasP : MonoBehaviour
{
    public int vidas;
    public string ultimaColl;
    public Animator animator;
    public int iFrames;
    private int framesInvencivilidad;
    // Start is called before the first frame update 
    void Start()
    {
        vidas = 3;
        ultimaColl = null;
        animator = GetComponent<Animator>();
        framesInvencivilidad = 0;
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
    }

    //Ficheros y Archivos Dato  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (framesInvencivilidad == 0)
        {
            if (collision.transform.tag == "Enemy")
            {
                vidas -= 1;
                framesInvencivilidad = iFrames;
                animator.SetInteger("IFrames", framesInvencivilidad);
            }
            if (collision.transform.tag == "MainCamera")
            {
                vidas -= 1;
                ultimaColl = collision.transform.tag;
                framesInvencivilidad = iFrames;
                animator.SetInteger("IFrames", framesInvencivilidad);
            }
            //Si el jugador se encuentra atrapado entre la camara y un obstaculo a 
            //los obstaculos se les quita el box collider 
            if (ultimaColl == "MainCamera" && collision.transform.tag == "Enemy")
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
            if (collision.transform.tag == "Enemy")
            {
                vidas -= 1;
                framesInvencivilidad = iFrames;
                animator.SetInteger("IFrames", framesInvencivilidad);
            }
        }
    }
}
