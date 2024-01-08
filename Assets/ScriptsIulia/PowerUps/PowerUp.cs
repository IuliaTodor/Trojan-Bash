using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "PowerUp")]
public class PowerUp : ScriptableObject
{
    public string ID;
    public string PowerUpName;
    [TextArea]public string description;
    public Sprite image;
    public int cost;
    public bool hasBeenPurchased = false;

    public virtual bool ApplyPowerUpEffect()
    {
        return true;
    }

    public virtual bool DiscardPowerUp()
    {
        return true;
    }
}
