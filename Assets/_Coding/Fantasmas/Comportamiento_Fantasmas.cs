using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fantasmas))]
public class Comportamiento_Fantasmas : MonoBehaviour
{
    public Fantasmas fantasmas { get; private set; }
    public float duration;

    private void Awake()
    {
        fantasmas = GetComponent<Fantasmas>();
    }

    public void Enable()
    {
        Enable(duration);
    }

    public virtual void Enable(float duration)
    {
        enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        enabled = false;

        CancelInvoke();
    }

}