using UnityEngine;

public class Logros : MonoBehaviour
{
    private ScoreManager scoreManager;
    private bool logroDesbloqueado;

    void Start()
    {
        // Aseg�rate de que este script est� en el mismo GameObject que ScoreManager o encuentra la referencia de otra manera.
        scoreManager = GetComponent<ScoreManager>();
        logroDesbloqueado = false;
    }

    void Update()
    {
        // Accede al puntaje desde ScoreManager y verifica si se deben desbloquear logros
        int puntajeActual = scoreManager.score;

        if (puntajeActual >= 1000 && !logroDesbloqueado)
        {
            DesbloquearLogro("Logro Desbloqueado");
            logroDesbloqueado = true;
        }
    }

    void DesbloquearLogro(string nombreLogro)
    {
        Debug.Log($"Logro Desbloqueado: {nombreLogro}");
    }
}
