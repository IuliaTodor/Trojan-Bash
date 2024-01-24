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
    }
    public void NotActive()
    {
        credit.SetActive(false);
    }
}
