using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowMovement : MonoBehaviour
{
    public float actualPosY;
    private float angle;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        actualPosY = transform.position.y;
    }

    private IEnumerator Movement()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        if (actualPosY > 0)
        {
            RotateArrow(-30);
            yield return new WaitForSeconds(1);
            ChangeArrowPosY();
        }
        else if (actualPosY < 0)
        {
            
        }

        RotateArrow(angle);
        yield return new WaitForSeconds(1);
        ChangeArrowPosY();

        ;
    }

    private void ChangeArrowPosY()
    {
        throw new System.NotImplementedException();
    }

    private void RotateArrow(float angle)
    {
        gameObject.transform.eulerAngles = Vector3.forward * angle;
    }
}
