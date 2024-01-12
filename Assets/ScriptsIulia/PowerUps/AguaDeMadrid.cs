using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/AguaDeMadrid")]
public class AguaDeMadrid : PowerUp
{
    public int bytesMultiplier;

    public override bool ApplyPowerUpEffect()
    {
        Debug.Log("activado power up");
        GameManager.instance.bytes *= bytesMultiplier;
        return true;
    }
}
