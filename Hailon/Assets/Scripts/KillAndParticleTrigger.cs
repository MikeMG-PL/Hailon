using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAndParticleTrigger : MonoBehaviour
{
    public ParticleSystem particle;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(particle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
