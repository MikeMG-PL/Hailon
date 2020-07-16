using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public ParticleSystem ballDestroy;

    public int collisionsCount;
    public int collisionsToEnableGravity = 3;
    public int collisionsToDestroy = 5;

    public List<Vector3> sizes;
    public int currentSize;

    bool maxCollisionsReached;

    void Start()
    {
        for (int i = 0; i < sizes.Count; i++)
        {
            if (sizes[i] == Vector3.Scale(transform.localScale, transform.parent.localScale)) currentSize = i;
        }
    }

    void Update()
    {
        if (!maxCollisionsReached && collisionsCount == collisionsToEnableGravity)
        {
            EnableGravity();
        }

        else if (collisionsCount >= collisionsToDestroy)
        {
            DestroyBall();
        }
    }

    void EnableGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        maxCollisionsReached = true;
    }

    void DestroyBall()
    {
        ParticleSystem destroyParticles = Instantiate(ballDestroy, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        destroyParticles.transform.parent = null;
        destroyParticles.transform.localScale = Vector3.one;

        Destroy(gameObject);
    }
}
