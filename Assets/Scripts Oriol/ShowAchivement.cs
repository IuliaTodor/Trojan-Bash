using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAchivement : MonoBehaviour
{
    private SpriteRenderer sprite;
    private void Start()
    {
        if (GameManager.Instance.SeDesbloqueo && gameObject.CompareTag("TrofeoPuntos"))
        {
            EnableAchivement();
        }
        else if (GameManager.Instance.SeDesbloqueo1 && gameObject.CompareTag("TrofeoMuerte"))
        {
            EnableAchivement();
        }
    }

    private void EnableAchivement()
    {
        sprite = gameObject.AddComponent<SpriteRenderer>();
        sprite.enabled = true;
    }
}
