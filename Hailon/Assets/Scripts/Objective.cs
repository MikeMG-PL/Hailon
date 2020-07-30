using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public event EventHandler ObjectiveReached;
    public ParticleSystem finishHit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(finishHit, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Vibration.Vibrate(100);
        }
    }

    protected virtual void OnObjectiveReached(EventArgs e)
    {
        EventHandler handler = ObjectiveReached;
        handler?.Invoke(this, e);
    }
}
