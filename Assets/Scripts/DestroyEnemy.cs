using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    //public static DestroyEnemy DestroyEn;
    public int dieEnemy = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            dieEnemy += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
          
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
