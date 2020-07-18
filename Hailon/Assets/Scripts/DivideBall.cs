using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DivideBall : MonoBehaviour
{
    List<GameObject> clonesInCollider = new List<GameObject>();
    Vector2 pos1, pos2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && !collision.isTrigger)
        {
            if (!CheckIfViable(collision.gameObject)) return;

            CreateTwoClones(collision.gameObject);
        }
    }

    void CreateTwoClones(GameObject ballObject)
    {
        Ball ball = ballObject.GetComponent<Ball>();
        Vector2 velocity = ballObject.GetComponent<Rigidbody2D>().velocity;

        CalculatePositions(ball, velocity);

        CreateBall(ball, velocity, pos1);
        CreateBall(ball, velocity, pos2);

        Destroy(ball.gameObject);
    }

    // Checking if the ball isn't just a clone that was spawned in the collider
    bool CheckIfViable(GameObject gameObject)
    {
        for (int i = 0; i < clonesInCollider.Count; i++)
        {
            if (gameObject == clonesInCollider[i]) return false;
        }

        return true;
    }

    void CalculatePositions(Ball ball, Vector2 velocity)
    {
        Vector3 pos1 = ball.transform.position;
        Vector3 pos2 = ball.transform.position;

        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
        {
            pos1.y += 0.05f;
            pos2.y -= 0.05f;
        }

        else
        {
            pos1.x += 0.05f;
            pos2.x -= 0.05f;
        }
    }

    void CreateBall(Ball ball, Vector2 velocity, Vector3 pos)
    {
        GameObject cloneBall = Instantiate(ball.gameObject, pos, ball.transform.rotation);
        clonesInCollider.Add(cloneBall);
        cloneBall.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && !collision.isTrigger)
        {
            clonesInCollider.Remove(collision.gameObject);
        }
    }
}
