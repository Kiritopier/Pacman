using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persiguiendo : Comportamiento_Fantasmas
{
    private void OnDisable()
    {
        fantasmas.scatter.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Nodos node = other.GetComponent<Nodos>();

        
        if (node != null && enabled && !fantasmas.frightened.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            
            foreach (Vector2 availableDirection in node.availableDirections)
            {
               
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (fantasmas.target.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }

            fantasmas.movement.SetDirection(direction);
        }
    }

}
