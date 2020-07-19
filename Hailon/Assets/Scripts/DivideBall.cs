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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && !spawned)
        {
            Divide(collision);
            ResetCollisions(collision.gameObject, instance);
            HideSprite();
            spawned = true;
        }
    }

    void Divide(Collider2D collision)
    {
        Vector2 velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        CalculatePosition(collision.gameObject.GetComponent<Ball>(), velocity);
        instance = Instantiate(collision.gameObject, pos, collision.transform.rotation);
        instance.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void ResetCollisions(GameObject baseObject, GameObject instance)
    {
        baseObject.GetComponent<Ball>().ResetBall();
        instance.GetComponent<Ball>().ResetBall();
    }

    void HideSprite()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(Kill(0.1f));
    }

    IEnumerator Kill(float s)
    {
        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(s);
        Destroy(gameObject);
    }

    void CalculatePosition(Ball ball, Vector2 velocity)
    {
        pos = ball.transform.position;

        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
            pos.y -= 0.05f;
        else
            pos.x += 0.05f;
    }
}
