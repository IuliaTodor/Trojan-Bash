using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int bytes;
    public TMP_Text bytesUI;
    //public ShopPowerUp[] shopPowerUps;
    public ShopTemplate[] shopPanels;
    public GameObject DescriptionUI;
    public Button[] purchaseBtn;

    // Start is called before the first frame update
    void Start()
    {
        //LoadPowerUps();
        //CheckPurchaseable();
        bytesUI.text = "Bytes: " + bytes.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddBytes()
    {
        Debug.Log("a");
        bytes += 100;
        bytesUI.text = "Bytes: " + bytes.ToString();
        //CheckPurchaseable();
    }

    //public void LoadPowerUps()
    //{
    //    for (int i = 0; i < shopPowerUps.Length; i++)
    //    {
    //        shopPanels[i].titleText.text = shopPowerUps[i].name;
    //        shopPanels[i].costText.text = shopPowerUps[i].cost.ToString() + " bytes";
    //        shopPanels[i].image.sprite = shopPowerUps[i].image;
    //        shopPanels[i].descriptionText.text = shopPowerUps[i].description;
    //    }
    //}

    //public void CheckPurchaseable()
    //{
    //    for (int i = 0; i < shopPowerUps.Length; i++)
    //    {
    //        if (bytes >= shopPowerUps[i].cost)
    //        {
    //            purchaseBtn[i].interactable = true;
    //        }

    //        else
    //        {
    //            purchaseBtn[i].interactable = false;
    //        }
    //    }
    //}

    public void PurchaseItem(int btnNum)
    {
        //if (bytes >= shopPowerUps[btnNum].cost)
        //{
        //    bytes -= shopPowerUps[btnNum].cost;
        //    bytesUI.text = "Bytes: " + bytes.ToString();
        //    Debug.Log(shopPowerUps[btnNum].cost);
        //    //CheckPurchaseable();
        //}
    }
}
