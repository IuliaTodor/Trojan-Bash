using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject cam;
    public GameObject prefab;
    public float bounsX;
    public float fercuencia;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        bounsX = cam.GetComponent<Camera>().orthographicSize * 1.6f;
        timer += Time.deltaTime;
        if (timer >= fercuencia)
        {
            float spawnPosY = Random.Range(-1f, -3f);
            timer = 0;
            Instantiate(prefab, new Vector3(cam.GetComponent<Transform>().position.x + bounsX, spawnPosY, prefab.GetComponent<Transform>().position.z), new Quaternion());
        }

    }
}
