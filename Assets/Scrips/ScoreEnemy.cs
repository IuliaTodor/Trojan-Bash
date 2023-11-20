using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Este codigo funciona con el de SpawnEnemy.cs.
/// Oriol comprueba si funciona con los tuyos.
/// Si tienes dudas pregunta.
/// Me niego ha cambiar nada por el momento
/// </summary>
public class ScoreEnemy : MonoBehaviour
{
    public GameObject player;
    private Transform _tr;
    public int puntos;
    private ScoreManager scoreManager;
    private List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Caballo");//Nombre del Objeto Jugador
        _tr = player.transform;
        if (puntos == 0) puntos = 25;
        scoreManager = GameObject.Find("ControladorPuntos").GetComponent<ScoreManager>();// poner el nobre del objeto que tenga el script "ScoreManager.cs"
    }

    // Update is called once per frame
    void Update()
    {
        list = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        foreach (GameObject obj in list)
        {
            Vector3 pos = obj.transform.position;
            if (pos.x < _tr.position.x)
            {
                obj.GetComponent<BoxCollider2D>().enabled = false;
                scoreManager.RaiseScore(puntos);
                obj.tag = "Corrupto";
                Debug.Log("Funciona");
            }
        }
    }
}
