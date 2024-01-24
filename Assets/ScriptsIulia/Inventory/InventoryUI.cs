using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryPanelDescription;
    [SerializeField] private TextMeshProUGUI DescriptionText;
    [SerializeField] private TextMeshProUGUI DescriptionName;
    private GameObject Canvas;


    [SerializeField] public Slot slot;
    [SerializeField] private Transform container; //El lugar donde se instancian los slots

    public List<Slot> slots = new List<Slot>();

    public static InventoryUI instance;



    void Start()
    {
        instance = this;
        //Si se van a perder estos componentes entre escenas no tiene sentido que sea Dontdestroyonload. 
        //Es mejor establecer estos componentes desde el código
        Canvas = GameObject.Find("ShopCanvas");
        inventoryPanel = Canvas.transform.GetChild(2).gameObject;
        inventoryPanelDescription = inventoryPanel.transform.GetChild(0).gameObject;
        DescriptionText = inventoryPanelDescription.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        DescriptionName = inventoryPanelDescription.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Debug.Log(inventoryPanel.name);
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
            newSlot.index = i;
            slots.Add(newSlot);
        }
    }

    public void DrawPowerUp(PowerUp powerUp, int powerUpIndex)
    {
        slot = slots[powerUpIndex];

        if (powerUp != null)
        {
            slot.SetSlotActive(true);
            slot.UpdateSlotUI(powerUp);
        }

        else
        {
            slot.SetSlotActive(false);
        }
    }

    private void SlotInteractionResponse(SlotInteraction type, int index)
    {
        if(type == SlotInteraction.Click)
        {
            UpdatePowerUpDescription(index);
        }
    }

    private void OnEnable()
    {
        Slot.slotInterationEvent += SlotInteractionResponse;
    }

    private void OnDisable()
    {
        Slot.slotInterationEvent -= SlotInteractionResponse;
    }


    private void UpdatePowerUpDescription(int index)
    {
        if (Inventory.instance.powerUps[index] != null) //Si hay un PowerUp en esta posición
        {
            DescriptionText.text = Inventory.instance.powerUps[index].description;
            DescriptionName.text = Inventory.instance.powerUps[index].PowerUpName;
            inventoryPanelDescription.SetActive(true);
        }

        else
        {
            inventoryPanelDescription.SetActive(false);
        }
    }
}