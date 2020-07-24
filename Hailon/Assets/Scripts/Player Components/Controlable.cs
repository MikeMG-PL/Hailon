using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlable : MonoBehaviour
{
    Vector3 touchPosition;
    Touch touch;
    RaycastHit2D hit;
    bool touchStarted;
    GameObject sample;

    void Update()
    {
        TouchSet();
        Sliding();
        ProperXPOS();
    }

    void Sliding()
    {
        if (hit.collider == GetComponent<CapsuleCollider2D>())
        {
            if (touch.phase == TouchPhase.Began)
            {
                sample = transform.GetChild(0).gameObject;
                sample = Instantiate(sample, new Vector2(touchPosition.x, transform.position.y), Quaternion.identity);
                transform.SetParent(sample.transform);
                touchStarted = true;
            }

            if (touchStarted == true)
                sample.transform.position = new Vector2(touchPosition.x, transform.position.y);
        }

        if (touch.phase == TouchPhase.Ended)
        {
            transform.SetParent(null);
            touchStarted = false;
            Destroy(sample);
        }
    }

    void ProperXPOS()
    {
        if (transform.position.x > 2.2f)
            transform.position = new Vector2(2.2f, -4.35f);

        if (transform.position.x < -2.2f)
            transform.position = new Vector2(-2.2f, -4.35f);
    }

    void TouchSet()
    {
        if (InputManager.IsMovementAllowed())
        {
            if (Input.touchCount == 0) return;

            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            hit = Physics2D.Raycast(touchPosition, Camera.main.transform.forward);
        }

    }
}
