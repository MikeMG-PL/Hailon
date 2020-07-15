using UnityEngine;

public class Ball : MonoBehaviour
{
    public ParticleSystem ballDestroy;

    public int collisionsCount;
    public int collisionsToEnableGravity = 3;
    public int collisionsToDestroy = 5;

    bool maxCollisionsReached;

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
