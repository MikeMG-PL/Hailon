using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public ParticleSystem finishHit;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(finishHit, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Debug.Log("You've won!");
        }
    }
}
