using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlable : MonoBehaviour
{
    Vector3 touchPosition;
    Touch touch;
    RaycastHit2D hit;

    void Update()
    {
        ProperYPOS();
        ProperXPOS();

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            
            hit = Physics2D.Raycast(touchPosition, Camera.main.transform.forward);
            if (hit.collider == gameObject.GetComponent<CapsuleCollider2D>())
            {
                transform.position = new Vector2(touchPosition.x, touchPosition.y);
                ProperYPOS();
                ProperXPOS();
            }
                
        }
    }

    void ProperXPOS()
    {
        if (transform.position.x > 2.2f)
            transform.position = new Vector2(2.2f, -4.339f);

        if (transform.position.x < -2.2f)
            transform.position = new Vector2(-2.2f, -4.339f);
    }

    void ProperYPOS()
    {
        Vector2 position = new Vector2(transform.position.x, -4.339f);
        transform.position = position;
    }
}
