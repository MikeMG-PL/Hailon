using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementBallCollisions : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Ball>().IncrementCollisionsCount();
            SoundManager.soundManager.Hit();
        }
    }
}
