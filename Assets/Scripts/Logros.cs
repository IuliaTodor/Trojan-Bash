using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logros : MonoBehaviour
{
    private ScoreManager scoreManager;
    private bool logroDesbloqueado;

    void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        logroDesbloqueado = false;
    }
    //ESTO DEBERIA FUNCIONAR TODO PERO FALTAN COSILLAS TIPO EL ENEMIGO Y OTRAS PERO GNO LUEGO LO RETOCO Y FALTA PONER LO DELA TIENDA DE CUANDO COJA OBJEYOS SE PONGAN
    void Update()
    {
        // Accede al puntaje desde ScoreManager y verifica si se deben desbloquear logros
        int puntajeActual = GameManager.instance.bytes;
        int enemigosMuertos = DestroyEnemy.DestroyEn.dieEnemy;
        bool bossMuerto = DestroyEnemy.DestroyEn.boss;
        //bool hasBeenPurcharsed = ShopManager.instance.allPowerUpsPurchased;
        if (puntajeActual >= 10000 && !logroDesbloqueado)
        {
            SceneManager.LoadScene("DavidScene");
        }
        if (enemigosMuertos >= 20 && !logroDesbloqueado)
        {
            SceneManager.LoadScene("DavidScene");
        }
        //if (hasBeenPurcharsed != false)
        //{
        //    SceneManager.LoadScene("DavidScene");
        //}
        //if (bossMuerto == true && !logroDesbloqueado)
        //{
        //    SceneManager.LoadScene("DavidScene");
        //}
    }
}
