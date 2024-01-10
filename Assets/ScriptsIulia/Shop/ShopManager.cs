using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public TMP_Text bytesUI;
    public PowerUp[] powerUps;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsGO; //La referencia al prefab en lugar del script
    public Button[] purchaseBtn;
    public bool allPowerUpsPurchased;
    public static ShopManager shp;

    // Start is called before the first frame update
    void Start()
    {
        //Para que solo aparezcan los que tienen algún Power Up asignado
        for (int i = 0; i < powerUps.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        LoadPowerUps();
        CheckPurchaseable();
        bytesUI.text = "Bytes: " + GameManager.instance.bytes.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddBytes()
    {
        GameManager.instance.bytes += 100;
        bytesUI.text = "Bytes: " + GameManager.instance.bytes.ToString();
        CheckPurchaseable();
    }

    public void LoadPowerUps()
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            shopPanels[i].titleText.text = powerUps[i].name;
            shopPanels[i].costText.text = powerUps[i].cost.ToString() + " B";
            shopPanels[i].image.sprite = powerUps[i].image;
            shopPanels[i].descriptionText.text = powerUps[i].description;
        }
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            if (GameManager.instance.bytes >= powerUps[i].cost && !powerUps[i].hasBeenPurchased)
            {
                purchaseBtn[i].interactable = true;
            }
            else
            {
                purchaseBtn[i].interactable = false;
            }

            if (powerUps[i].hasBeenPurchased)
            {
                purchaseBtn[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btnNum)
    {
        if (GameManager.instance.bytes >= powerUps[btnNum].cost)
        {
            GameManager.instance.bytes -= powerUps[btnNum].cost;
            bytesUI.text = "Bytes: " + GameManager.instance.bytes.ToString();
            CheckPurchaseable();

            powerUps[btnNum].hasBeenPurchased = true;

            Inventory.instance.AddPowerUp(powerUps[btnNum]);
            
        }
        foreach(PowerUp powerUp in powerUps)
        {
            if(powerUp.hasBeenPurchased == false)
            {
                allPowerUpsPurchased = false;
            }
            
            
        }
        
    }

    
}
