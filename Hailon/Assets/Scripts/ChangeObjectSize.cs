using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Resize { Decrease, Increase };

public class ChangeObjectSize : MonoBehaviour
{
    public Resize resize;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !collision.isTrigger)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            if (resize == Resize.Decrease && ball.currentSize != 0)
            {
                ball.transform.localScale = ball.sizes[ball.currentSize - 1];
                ball.currentSize--;
            }

            else if (resize == Resize.Increase && ball.currentSize != ball.sizes.Count)
            {
                Debug.Log(ball.currentSize);
                ball.transform.localScale = ball.sizes[ball.currentSize + 1];
                ball.currentSize++;
            }
        }
    }
}
