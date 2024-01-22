using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Creditos : MonoBehaviour
{
    public GameObject credit;

    public void Active()
    {
        credit.SetActive(true);
        Debug.Log("Hi");
    }
    public void NotActive()
    {
        credit.SetActive(false);
        Debug.Log("KMS");
    }
}
