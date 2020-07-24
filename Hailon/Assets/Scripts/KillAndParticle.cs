using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Notification = Notifications.Notification;

public class KillAndParticle : MonoBehaviour
{
    public bool godMode;
    public ParticleSystem particle;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !godMode)
        {
            if(transform.CompareTag("Player"))
                Notifications.Notify(Notification.PlayerKilled);

            Instantiate(particle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
