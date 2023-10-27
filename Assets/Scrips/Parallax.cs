using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEfect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEfect));
        float dist = (cam.transform.position.x * parallaxEfect);

        transform.position = new Vector2(startPos + dist, transform.position.y);


        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;

    }
}

