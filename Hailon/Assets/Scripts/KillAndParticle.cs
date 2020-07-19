using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAndParticle : MonoBehaviour
{
    public bool godMode;
    public ParticleSystem particle;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !godMode)
        {
            Instantiate(particle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
