using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowMovement : MonoBehaviour
{
    private float angle;
    private Vector2 direction;

    private Rigidbody2D rb;
    public static arrowMovement arrow;

    private void Awake()
    {
        if (arrow == null)
        {
            arrow = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (arrow != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetAngleAndDirection();
        StartCoroutine(Movement());        
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 3.01 || transform.position.y < -3.01)
        {
            transform.eulerAngles = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
    }

    private IEnumerator Movement()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 1f));
        RotateArrow(angle);
        yield return new WaitForSeconds(1);
        ChangeArrowPosY(direction);
    }

    private void ChangeArrowPosY(Vector2 direction)
    {
        rb.velocity = direction * 8;
    }
    private void GetAngleAndDirection()
    {
        if (transform.position.y >= 0)
        {
            angle = 30;
            direction = Vector2.down;
        }
        else if (transform.position.y < 0)
        {
            angle = -45;
            direction = Vector2.up;
        }
    }

    private void RotateArrow(float angle)
    {
        transform.eulerAngles = Vector3.forward * angle;
    }
}
