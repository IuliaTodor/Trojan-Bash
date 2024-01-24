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
        dieEnemy = 0;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            dieEnemy += 1;
            Debug.Log("Enemigo muerto" +  dieEnemy);
            Destroy(collision.gameObject);
            Destroy(gameObject);
          
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
