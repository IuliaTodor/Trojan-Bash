using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject balaPrefab;
    public int poolSize = 10;

    private List<GameObject> balas = new List<GameObject>();

    private void Start()
    {
        // Llena el pool con balas preinstanciadas.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bala = Instantiate(balaPrefab);
            bala.SetActive(false);
            balas.Add(bala);
        }
    }

    public GameObject ObtenerBala()
    {
        // Busca una bala inactiva en el pool y la devuelve.
        foreach (GameObject bala in balas)
        {
            if (!bala.activeInHierarchy)
            {
                return bala;
            }
        }
        // Si todas las balas están en uso, puedes ajustar la lógica para clonar más balas.
        return null;
    }
}
