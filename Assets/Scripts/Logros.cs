using UnityEngine;
using UnityEngine.SceneManagement;

public class Logros : MonoBehaviour
{
    private ScoreManager scoreManager;
    private DestroyEnemy dm;
    private ShopManager sm;
    public bool logroDesbloqueado = false;
    void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        dm = GameObject.Find("BichoProyectil").GetComponent<DestroyEnemy>();
        sm = GameObject.Find("Shop").GetComponent<ShopManager>();
    }

    void Update()
    {
        // Accede al puntaje desde ScoreManager y verifica si se deben desbloquear logros
        int puntajeActual = GameManager.Instance.bytes;
        int enemigosMuertos = dm.dieEnemy;

        if (puntajeActual >= 10000 && !logroDesbloqueado)
        {
            GameManager.Instance.SeDesbloqueo = true;
        }

        if (enemigosMuertos >= 20 && !GameManager.Instance.SeDesbloqueo1)
        {
            GameManager.Instance.SeDesbloqueo1 = true;
        }

    }
}