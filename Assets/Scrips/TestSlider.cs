using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSlider : MonoBehaviour
{
    public Slider musicSlider;
    public Slider efectSlider;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("Test").GetComponent<AudioManager>();//Donde pone Test poner el nombre del Objeto con el componente AudioManager
        Slider[] sliders = GetComponentsInChildren<Slider>();
        musicSlider = sliders[0];
        musicSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        efectSlider = sliders[1];
        efectSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void ValueChangeCheck()
    {
        if (audioManager != null)
        {
            audioManager.musicVolume = musicSlider.value;
            audioManager.efectVolume = efectSlider.value;
        }
    }
}
