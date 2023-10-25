using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float velocidad;
    public float aceleracion;
    public int tiempo;
    private Transform rb;
    private int cuenta;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position += new Vector3(velocidad, 0f, 0f);
        cuenta++;
        if (cuenta == tiempo) 
        {
            velocidad += aceleracion;
            cuenta = 0;
        }
    }
}
