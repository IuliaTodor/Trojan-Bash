using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goDieScene : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        int life = VidasP.vid.vidas;
        if (life == 0)
        {
            SceneManager.LoadScene("GameOver");
        } 
    }
}
