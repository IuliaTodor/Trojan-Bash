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
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Bytes dentro del juego: " + GameManager.Instance.bytes);
    }
    public void RaiseScore(int s)
    {
        score += s;
        GameManager.Instance.bytes += s;
        scoreText.text = score.ToString();
    }
}
