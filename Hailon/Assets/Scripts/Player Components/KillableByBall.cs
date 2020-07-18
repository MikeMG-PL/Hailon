using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableByBall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("LEVEL FALIED!");
            FailLevel();
        }
    }

    void FailLevel()
    {
        Destroy(gameObject);
    }
}
