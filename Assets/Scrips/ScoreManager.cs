using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        instance= this;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void RaiseScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }
}
