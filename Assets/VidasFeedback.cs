using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasFeedback : MonoBehaviour
{
    public Image imageFeedback;
    //public static VidasFeedback instance;
    // Start is called before the first frame update
    void Start()
    {
        imageFeedback = GetComponent<Image>();
    }
    private void OnEnable()
    {
        VidasP.ChangeColor += ShowLifesFeedback;
    }
    private void OnDisable()
    {
        VidasP.ChangeColor -= ShowLifesFeedback;
    }

    public void ShowLifesFeedback(Color color)
    {
        var colorA = color;
        colorA.a = 0.5f;
        color = colorA;
        imageFeedback.enabled = true;
        imageFeedback.color = color;
        StartCoroutine(HoldeaBbsita());
    }

    public IEnumerator HoldeaBbsita()
    {
        yield return new WaitForSeconds(1);
        imageFeedback.enabled = false;
    }
}
