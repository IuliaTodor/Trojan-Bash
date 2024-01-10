using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Corrupto" || collision.gameObject.tag == "bicho") { Destroy(collision.gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Corrupto" || collision.gameObject.tag == "bicho")
        {
            Destroy(collision.gameObject);
        }
    }
}
