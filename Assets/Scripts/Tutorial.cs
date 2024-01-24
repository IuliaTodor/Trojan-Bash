using System.Collections;
using UnityEngine;

public class DestruirCanvasYPausar : MonoBehaviour
{
    void Start()
    {
        // Inicia la Coroutine para destruir el Canvas después de 3 segundos
        StartCoroutine(DestruirDespuesDe3Segundos());
       
    }

    IEnumerator DestruirDespuesDe3Segundos()
    {
        // Espera 3 segundos
        yield return new WaitForSeconds(3f);

        // Destruye el objeto Canvas al que está adjunto este script
        Destroy(gameObject);

    }
}