using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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
        //Para que solo aparezcan los que tienen alg�n Power Up asignado
        for (int i = 0; i < powerUps.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        LoadPowerUps();
        CheckPurchaseable();
        bytesUI.text = GameManager.Instance.bytes.ToString() + " Bytes";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddBytes()
    {
        GameManager.Instance.bytes += 1000;
        bytesUI.text = "Bytes: " + GameManager.Instance.bytes.ToString();
        CheckPurchaseable();
    }

    public void LoadPowerUps()
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            shopPanels[i].titleText.text = powerUps[i].name;
            shopPanels[i].costText.text = powerUps[i].cost.ToString();
            shopPanels[i].image.sprite = powerUps[i].image;
            shopPanels[i].descriptionText.text = powerUps[i].description;
        }
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            if (GameManager.Instance.bytes >= powerUps[i].cost)
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
        if (GameManager.Instance.bytes >= powerUps[btnNum].cost)
        {
            GameManager.Instance.bytes -= powerUps[btnNum].cost;
            bytesUI.text = "Bytes: " + GameManager.Instance.bytes.ToString();
            CheckPurchaseable();
            purchaseBtn[btnNum].interactable = false;
            powerUps[btnNum].hasBeenPurchased = true;

            Inventory.instance.AddPowerUp(powerUps[btnNum]);
            DataManager.instance.SaveData();
            
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
