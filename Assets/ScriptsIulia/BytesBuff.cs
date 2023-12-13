using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PowerUp/ByteBuff")]
public class BytesBuff : PowerUpEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<ScoreManager>().score *= amount;
    }
}
