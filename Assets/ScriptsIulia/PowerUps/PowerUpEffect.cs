using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    public PowerUp powerup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("caballo"))
        {
            powerup.ApplyPowerUpEffect(collision.gameObject);
            Destroy(gameObject);
        }
    
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if(collision.CompareTag("bicho"))
        {
            return;
        }
    }
}
