using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject cam;
    public float camBoundsX;
    public float fercuencia;
    private float timer;

    public GameObject folder;
    public GameObject trash;
    public GameObject arrow;
    public GameObject hand;

    private List<GameObject> enemyList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        enemyList.Add(folder);
        enemyList.Add(trash);
        enemyList.Add(arrow); 
        enemyList.Add(hand);
    }

    // Update is called once per frame
    void Update()
    {
        camBoundsX = cam.GetComponent<Camera>().orthographicSize * 1.6f;
        timer += Time.deltaTime;
        if (timer >= fercuencia)
        {
            float spawnPosY = Random.Range(-3f, 3f);
            timer = 0;
            Instantiate(GetRandomEnemy(), new Vector3(cam.GetComponent<Transform>().position.x + camBoundsX, spawnPosY, 0), new Quaternion());
        }

    }

    private GameObject GetRandomEnemy()
    {
        return enemyList[Random.Range(0, 4)];
    }

    
}
