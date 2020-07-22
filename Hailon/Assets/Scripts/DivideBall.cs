using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DivideBall : MonoBehaviour
{
    public ParticleSystem particle;

    Vector2 pos;
    bool spawned;
    GameObject instance;
    Vector2 velocity;
    Vector2 force;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && !spawned)
        {
            Divide(collision);
            ResetCollisions(collision.gameObject, instance);
            Kill();
            spawned = true;
        }
    }

    void Divide(Collider2D collision)
    {
        velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        CalculatePosition(collision.gameObject.GetComponent<Ball>(), velocity);
        instance = Instantiate(collision.gameObject, pos, collision.transform.rotation);

        DividePhysics(collision.gameObject);
    }

    void DividePhysics(GameObject collidingObject)
    {
        instance.GetComponent<Rigidbody2D>().velocity = velocity;

        instance.GetComponent<Ball>().dividerBall = true;
        collidingObject.GetComponent<Ball>().dividerBall = true;

        instance.GetComponent<Rigidbody2D>().AddForce(-force, ForceMode2D.Impulse);
        collidingObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }

    void ResetCollisions(GameObject baseObject, GameObject instance)
    {
        baseObject.GetComponent<Ball>().ResetBall();
        instance.GetComponent<Ball>().ResetBall();
    }

    void Kill()
    {
        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void CalculatePosition(Ball ball, Vector2 velocity)
    {
        pos = ball.transform.position;

        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
        {
            pos.y -= 0.05f;
            force.y -= 0.75f;
        }

        else
        {
            pos.x += 0.05f;
            force.x += 0.75f;
        }

    }
}
