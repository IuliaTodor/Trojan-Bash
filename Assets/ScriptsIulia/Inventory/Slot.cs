using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SlotInteraction
{
    Click,
    ApplyEffect,
    Remove
}
public class Slot : MonoBehaviour
{
    public static Action<SlotInteraction, int> slotInterationEvent;
    public int index;
    [SerializeField] private Image icon;

    public void UpdateSlotUI(PowerUp powerUp)
    {
        icon.sprite = powerUp.image;
    }

    public void SetSlotActive(bool state)
    {
        icon.gameObject.SetActive(state);
    }

    public void ClickSlot()
    {
        if(slotInterationEvent != null)
        {
            slotInterationEvent.Invoke(SlotInteraction.Click, index);
        }
    }
}
