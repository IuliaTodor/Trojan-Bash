using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    public PowerUp powerup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerup.ApplyPowerUpEffect(collision.gameObject);
        Destroy(gameObject);
    }
}
