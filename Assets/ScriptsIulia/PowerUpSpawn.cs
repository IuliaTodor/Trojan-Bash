using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] spawnObjects;

    public GameObject cam;
    public float camBoundsX;
    public float fercuencia;
    private float timer;

    private Inventory inventory;

    void Start()
    {

    }

    void Update()
    {
        camBoundsX = cam.GetComponent<Camera>().orthographicSize * 1.6f;
        timer += Time.deltaTime;
        if (timer >= fercuencia)
        {
            float spawnPosY = Random.Range(-3f, 3f);
            timer = 0;
            Instantiate(GetRandomPowerUp(), new Vector3(cam.GetComponent<Transform>().position.x + camBoundsX, spawnPosY, 0), new Quaternion());
        }

    }

    private PowerUp GetRandomPowerUp()
    {
        return inventory.powerUps[Random.Range(0, 2)];
    }
}
