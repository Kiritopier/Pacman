using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota_Poder : Pelota
{
    public float Duracion = 8.0f;

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().ComerPelotaPoder(this);
    }
}
