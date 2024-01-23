using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryPanelDescription;
    [SerializeField] private TextMeshProUGUI DescriptionText;
    [SerializeField] private TextMeshProUGUI DescriptionName;


    [SerializeField] public Slot slot;
    [SerializeField] private Transform container; //El lugar donde se instancian los slots

    public List<Slot> slots = new List<Slot>();

    public static InventoryUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        instance = this;
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
        if (Inventory.instance.powerUps[index] != null) //Si hay un PowerUp en esta posici�n
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