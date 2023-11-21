using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager hand;

    public GameObject Bullet;
    private int[] angles = new int[3] { 0, 90, 180 };
    public int actualAngle;

    private void Awake()
    {
        if (hand == null)
        {
            hand = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (hand != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ChangeDirection();
        Shoot();
    }

    private void Shoot()
    {
        Instantiate(Bullet, transform.position, new Quaternion());
    }

    private void ChangeDirection()
    {
        if (transform.position.y >= 0)
        {
            actualAngle = angles[UnityEngine.Random.Range(1, 3)];
            transform.eulerAngles = Vector3.forward * actualAngle;
        }
        else if (transform.position.y < 0)
        {
            actualAngle = angles[UnityEngine.Random.Range(0, 2)];
            transform.eulerAngles = Vector3.forward * actualAngle;
        }
    }

}
