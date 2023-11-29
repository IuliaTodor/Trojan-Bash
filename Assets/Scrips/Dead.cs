using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private MoveCamera _camera;
    private MoveCamera background;
    private EnemySpawn spawn;
    // Start is called before the first frame update
    void Start()
    {
        // Objetos con el script MoveCamera
        _camera = GameObject.Find("Main Camera").GetComponent<MoveCamera>();
        background = GameObject.Find("Background ").GetComponent<MoveCamera>();
        //Objetos con SpawnEnemy
        spawn = GameObject.Find("Spawner").GetComponent<EnemySpawn>();
        // Desactivamos los scripts

    }

    // Update is called once per frame
    void Update()
    {
        // Poner pantalla de muerte, la animacion dura 304 frames

    }
    // Desactivamos los scripts
    public void Disenable()
    {
        GetComponent<MovimientoPersonaje>().enabled = false;
        GetComponentInChildren<ControlDeDisparo>().enabled = false;
        _camera.enabled = false;
        background.enabled = false;
        spawn.enabled = false;
    }

}
