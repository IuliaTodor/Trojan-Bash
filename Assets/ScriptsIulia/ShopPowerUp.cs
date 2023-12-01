using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "ShopPowerUp")]
public class ShopPowerUp : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite image;
    public int cost;
}
