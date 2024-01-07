using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
   
    [SerializeField] private Slot slot;
    [SerializeField] private Transform container; //El lugar donde se instancian los slots

    private List<Slot> slots = new List<Slot>();


    // Start is called before the first frame update
    void Start()
    {
        LoadInventory();
    }
    
    public void ToggleInventoryPanel()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    private void LoadInventory()
    {
        for (int i = 0; i < Inventory.instance.slotsNumber; i++)
        {
            Slot newSlot = Instantiate(slot, container);
            newSlot.index= i;
            slots.Add(newSlot);
            
        }
    }
}
