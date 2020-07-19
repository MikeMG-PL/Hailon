﻿using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public ParticleSystem ballDestroy;

    protected int collisionsCount;
    public int collisionsToEnableGravity = 3;
    public int collisionsToDestroy = 5;
    protected float timer;

    public List<Vector3> sizes;
    public int currentSize;

    bool maxCollisionsReached;

    void Start()
    {
        for (int i = 0; i < sizes.Count; i++)
        {
            if (transform.parent != null)
            {
                if (sizes[i] == Vector3.Scale(transform.localScale, transform.parent.localScale)) currentSize = i;
            }

            else
            {
                if (sizes[i] == transform.localScale) currentSize = i;
            }
        }
    }

    float smallTimer;
    void Update()
    {
        if (GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezeAll)
        {
            timer += Time.deltaTime;

            if (GetComponent<Rigidbody2D>().velocity.magnitude <= 3.025f && timer <= 0.25f)
                Destroy(gameObject);
            if (GetComponent<Rigidbody2D>().velocity.magnitude <= 2 && timer > 5f)
                DestroyBall();

            if (GetComponent<Rigidbody2D>().velocity.magnitude <= 4 && maxCollisionsReached)
            {
                smallTimer += Time.deltaTime;

                if (smallTimer >= 1)
                {
                    DestroyBall();
                    smallTimer = 0;
                }
            }
            else
                smallTimer = 0;
        }


        if (timer >= 10)
            DestroyBall();

        if (!maxCollisionsReached && collisionsCount == collisionsToEnableGravity)
            EnableGravity();

        else if (collisionsCount >= collisionsToDestroy)
            DestroyBall();
    }

    void EnableGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        maxCollisionsReached = true;
    }

    public void ResetBall()
    {
        timer = 0;
        collisionsCount = 0;
    }

    public void IncrementCollisionsCount()
    {
        collisionsCount++;
    }

    void DestroyBall()
    {
        ParticleSystem destroyParticles = Instantiate(ballDestroy, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        destroyParticles.transform.parent = null;
        destroyParticles.transform.localScale = Vector3.one;

        Destroy(gameObject);
    }
}
