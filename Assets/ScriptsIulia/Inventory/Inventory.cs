using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [SerializeField] public int slotsNumber;
    [SerializeField] public static Inventory instance;

    [SerializeField] public PowerUp[] powerUps;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        powerUps = new PowerUp[slotsNumber];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPowerUp(PowerUp powerUp)
    {
        for(int i = 0; i < powerUps.Length; i++)
        {
            if (powerUps[i] == null) //As� no se sobreescriben los PowerUp
            {
                powerUps[i] = powerUp; //El PowerUp se a�ade en el slot
                InventoryUI.instance.DrawPowerUp(powerUp, i);
                return;
            }
        }
    }
}
