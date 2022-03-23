using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MovimientoPacman : MonoBehaviour
{
    public float speed;
    public float dirX;
    public float dirY;
    public SpriteRenderer spr;
    public new Collider2D collider { get; private set; }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");

        collider = GetComponent<Collider2D>();

        transform.Translate(Vector3.right * dirX * speed);

        if (dirX > 0)
        {
            spr.flipX = false;
        }
        else
        {
            spr.flipX = true;
        }

        dirY = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * dirY * speed);

        if (dirY > 0)
        {
            spr.flipY = false;
        }
        else
        {
            spr.flipY = true;
        }



    }
}
