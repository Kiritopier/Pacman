using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class _MovimientoPacman : MonoBehaviour
{
    public float speed;
    public float dirX;
    public float dirY;
    public SpriteRenderer spr;

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");

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
        
        if(dirY > 0)
        {
            spr.flipY = false;
        }
        else
        {
            spr.flipY= true;
        }
    
    
    
    }


}
