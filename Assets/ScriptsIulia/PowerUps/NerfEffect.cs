using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PowerUps/Nerf")] 
public class NerfEffect : PowerUp
{
    public float speedBoost;

    public override void ApplyPowerUpEffect(GameObject target)
    {
        Debug.Log("activado power up");
        MovimientoPersonaje.instance.velocidadMovimiento *= speedBoost;
    }
}
