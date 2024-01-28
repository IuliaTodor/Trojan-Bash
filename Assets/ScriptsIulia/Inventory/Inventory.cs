using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public int slotsNumber;
    [SerializeField] public static Inventory instance;

    [SerializeField] public PowerUp[] powerUps;

    void Start()
    {
        instance = this;
        powerUps = new PowerUp[slotsNumber];
        DataManager.instance.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPowerUp(PowerUp powerUp)
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            if (powerUps[i] == null) //Así no se sobreescriben los PowerUp
            {
                powerUps[i] = powerUp; //El PowerUp se añade en el slot
                InventoryUI.instance.DrawPowerUp(powerUp, i);
                return;
            }
        }
    }
}
