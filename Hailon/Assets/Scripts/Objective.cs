﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public ParticleSystem finishHit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(finishHit, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Debug.Log("You've won!");
            Vibration.Vibrate(100);
        }
    }
}
