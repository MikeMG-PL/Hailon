using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlable : MonoBehaviour
{
    Vector3 touchPosition;
    Touch touch;
    RaycastHit2D hit;
    bool touchStarted;

    void Update()
    {
        TouchSet();

        if (hit.collider == GetComponent<CapsuleCollider2D>())
        {
            if (touch.phase == TouchPhase.Began)
                touchStarted = true;

            if (touchStarted == true)
                transform.position = new Vector2(touchPosition.x, transform.position.y);
        }

        if (touch.phase == TouchPhase.Ended)
            touchStarted = false;

        //ProperYPOS();
        ProperXPOS();
    }

    void ProperXPOS()
    {
        if (transform.position.x > 2.2f)
            transform.position = new Vector2(2.2f, -4.35f);

        if (transform.position.x < -2.2f)
            transform.position = new Vector2(-2.2f, -4.35f);
    }

    /*void ProperYPOS()
    {
        Vector2 position = new Vector2(transform.position.x, -4.35f);
        transform.position = position;
    }*/

    void TouchSet()
    {
        if (Input.touchCount == 0) return;

        touch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0;
        hit = Physics2D.Raycast(touchPosition, Camera.main.transform.forward);
    }
}
