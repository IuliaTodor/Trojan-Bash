using System;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float velocidad = 5.0f;
    private Rigidbody2D rb;

    public static BulletMovement bullet;
    private void Awake()
    {
        if (bullet == null)
        {
            bullet = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (bullet != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (GetBulletDirection() * velocidad);
    }

    private Vector3 GetBulletDirection()
    {
        switch (HandManager.hand.actualAngle)
        {
            case 0:
                return Vector3.up;
            case 90:
                return Vector3.left;
            default: 
                return Vector3.down;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = HandManager.hand.gameObject.transform.position;
    }
}

