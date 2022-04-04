using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispersion : Comportamiento_Fantasmas
{
    private void OnDisable()
    {
        fantasmas.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Nodos node = other.GetComponent<Nodos>();

        
        if (node != null && enabled && !fantasmas.frightened.enabled)
        {
            
            int index = Random.Range(0, node.availableDirections.Count);

          
            if (node.availableDirections[index] == -fantasmas.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                
                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            fantasmas.movement.SetDirection(node.availableDirections[index]);
        }
    }

}