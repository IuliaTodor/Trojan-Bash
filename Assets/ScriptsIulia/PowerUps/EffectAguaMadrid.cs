using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/AguaDeMadrid")]
public class EffectAguaMadrid : PowerUp
{
    public int bytesMultiplier;

    public override void ApplyPowerUpEffect(GameObject target)
    {
        Debug.Log("activado power up");
        ScoreManager.instance.score *= bytesMultiplier;
    }
}
