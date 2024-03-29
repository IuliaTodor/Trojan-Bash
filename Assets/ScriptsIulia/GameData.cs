using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class GameData
{
    public int bytes;
    public PowerUp[] powerUps;
    // public List<Slot> slots;
    public List<Sprite> images;
    public float sliderMusicValue;
    public float sliderSFXValue;
    public bool logroPuntos;
    public bool logroMatar;
}
