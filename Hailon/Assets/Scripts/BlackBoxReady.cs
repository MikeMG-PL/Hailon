using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BlackBoxReady : MonoBehaviour
{
    float timer;
    Collider2D[] colliders;

    void Start()
    {
        colliders = GetComponents<Collider2D>();

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.25f)
            SwitchCollidersOn();
    }

    void SwitchCollidersOn()
    {
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = transform;
            }
        }
    }
}
