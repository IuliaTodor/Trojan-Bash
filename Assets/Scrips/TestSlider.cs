using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSlider : MonoBehaviour
{
    public Slider musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        musicSlider = GetComponent<Slider>();
        musicSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void ValueChangeCheck()
    {
        Debug.Log(musicSlider.value);
    }
}
