using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "PowerUp")]
public abstract class PowerUp : ScriptableObject
{
    public string ID;
    public string PowerUpName;
    [TextArea]public string description;
    public Sprite image;
    public int cost;
    public bool hasBeenPurchased = false;
    public float duration;

    public abstract void ApplyPowerUpEffect(GameObject target);
}
