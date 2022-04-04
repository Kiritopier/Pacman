using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasmas : MonoBehaviour
{
    public Movimiento movement { get; private set; }
    public Fantamas_Casa home { get; private set; }
    public Dispersion scatter { get; private set; }
    public Persiguiendo chase { get; private set; }
    public Fantasmas_Asustados frightened { get; private set; }
    public Comportamiento_Fantasmas initialBehavior;
    public Transform target;
    public int points = 200;

    private void Awake()
    {
        movement = GetComponent<Movimiento>();
        home = GetComponent<Fantamas_Casa>();
        scatter = GetComponent<Dispersion>();
        chase = GetComponent<Persiguiendo>();
        frightened = GetComponent<Fantasmas_Asustados>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();

        frightened.Disable();
        chase.Disable();
        scatter.Enable();

        if (home != initialBehavior)
        {
            home.Disable();
        }

        if (initialBehavior != null)
        {
            initialBehavior.Enable();
        }
    }

    public void SetPosition(Vector3 position)
    {
        
        position.z = transform.position.z;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (frightened.enabled)
            {
                FindObjectOfType<GameManager>().ComiendoFantasmas(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanComiendo();
            }
        }
    }

}
