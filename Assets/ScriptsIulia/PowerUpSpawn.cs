using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public List<GameObject> InventoryPowerUpList;

    public GameObject cam;
    public float camBoundsX;
    public float fercuencia;
    private float timer;

    void Update()
    {
        camBoundsX = cam.GetComponent<Camera>().orthographicSize * 1.6f;
        timer += Time.deltaTime;
        if (timer >= fercuencia)
        {
            float spawnPosY = Random.Range(-3f, 3f);
            timer = 0;

            //Asegura que al menos un power up sea no null
            if (GameManager.Instance.powerUps.Any(p => p != null) || InventoryPowerUpList.Count > 0)

            {
                Debug.Log("entra a instanciar");
                Instantiate(GetRandomPowerUp(), new Vector3(cam.GetComponent<Transform>().position.x + camBoundsX, spawnPosY, 0), new Quaternion());
            }
        }

    }

    private GameObject GetRandomPowerUp()
    {
        InventoryPowerUpList = PowerUpList();
        if (InventoryPowerUpList.Count > 0)
        {
            Debug.Log("entra a random");
            return InventoryPowerUpList[Random.Range(0, InventoryPowerUpList.Count)];
        }

        return null;

    }

    private List<GameObject> PowerUpList()
    {
        InventoryPowerUpList.Clear();

        foreach (var powerUp in GameManager.Instance.powerUps)
        {
            if (powerUp != null)
            {
                // Devuelve el primer SpawnObject que cumpla una cierta condición. En este caso que no sea nulo y que su nombre sea igual al ID del power up
                GameObject matchingSpawnObject = spawnObjects.FirstOrDefault(obj => obj != null && obj.name == powerUp.ID);

                if (matchingSpawnObject != null && !InventoryPowerUpList.Contains(matchingSpawnObject))
                {
                    Debug.Log("Found power-up: " + powerUp.ID);
                    Debug.Log("Added to InventoryPowerUpList: " + powerUp.ID);
                    InventoryPowerUpList.Add(matchingSpawnObject);
                }
            }
        }

        return InventoryPowerUpList;

    }
}
