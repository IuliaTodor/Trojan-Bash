using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestThing : MonoBehaviour
{
    public GameObject cam;
    public int vidasTest;
    public float boundsX;
    public Transform camPos;
    // Start is called before the first frame update
    void Start()
    {
        camPos = cam.transform;
        boundsX =  camPos.position.x - cam.GetComponent<Camera>().orthographicSize * 2;
    }

    // Update is called once per frame
    void Update()
    {
        boundsX = camPos.position.x - cam.GetComponent<Camera>().orthographicSize * 1.8f;
        //Mira si esta en una mitad o en otra de la pantalla
        //if (boundsX > this.GetComponent<Transform>().position.x) vidasTest += 1;
        if (this.GetComponent<Transform>().position.x < boundsX) vidasTest += 1;
    }

}
