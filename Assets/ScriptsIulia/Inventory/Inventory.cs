using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public int slotsNumber;
    [SerializeField] public static Inventory instance;

    [SerializeField] private PowerUp[] powerUps;

    // Start is called before the first frame update
    void Start()
    {
        instance= this;
        powerUps = new PowerUp[slotsNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
