using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantamas_Casa : Comportamiento_Fantasmas
{
    

    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        
        if (gameObject.activeSelf)
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            fantasmas.movement.SetDirection(-fantasmas.movement.direction);
        }
    }

    

}
