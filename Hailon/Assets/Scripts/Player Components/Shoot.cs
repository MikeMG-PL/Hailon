using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class Shoot : MonoBehaviour
{
    public new Camera camera;
    public GameObject ballPrefab;
    public LineRenderer lineRenderer;
    public float power = 10f;
    public float maxDrag = 5f;

    GameObject newBall;
    Touch touch;
    Rigidbody2D ballRigidbody;
    Vector3 dragStartPosition, dragReleasePosition, draggingPosition, touchPosition, pos;
    RaycastHit2D hit;
    bool dragging, cooldown;

    void Start()
    {
        if (lineRenderer == null)
        {
            Debug.Log("You didn't set up line renderer");
            lineRenderer = GetComponent<LineRenderer>();
        }
        StartCoroutine(SetUpNewBall());
    }

    void Update()
    {
        TouchSet();

        if (touch.phase == TouchPhase.Began && hit.collider != null && hit.transform.CompareTag("Ball"))
        {
            dragging = true;
            DragStart();
        }

        if (dragging)
        {
            if (touch.phase == TouchPhase.Moved)
                Dragging();
            else if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
                dragging = false;
            }
        }
    }

    void DragStart()
    {

        //dragStartPosition = camera.ScreenToWorldPoint(touch.position);
        //dragStartPosition.z = 0;


        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, dragStartPosition);
    }

    void Dragging()
    {
        draggingPosition = camera.ScreenToWorldPoint(touch.position);
        draggingPosition.z = 0;


        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(1, draggingPosition);

    }

    void DragRelease()
    {
        lineRenderer.positionCount = 0;


        dragReleasePosition = camera.ScreenToWorldPoint(touch.position);
        dragReleasePosition.z = 0;



        Vector3 force = dragStartPosition - dragReleasePosition;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        newBall.GetComponent<Rigidbody2D>().isKinematic = false;
        ballRigidbody.AddForce(clampedForce, ForceMode2D.Impulse);
        ballRigidbody.constraints = RigidbodyConstraints2D.None;
        ballRigidbody.GetComponent<CircleCollider2D>().isTrigger = false;
        newBall.transform.SetParent(null);

        StartCoroutine(SetUpNewBall());

    }

    void TouchSet()
    {
        pos = new Vector2(transform.position.x, transform.position.y + 1.75f);
        dragStartPosition = pos;

        if (Input.touchCount == 0) return;

        touch = Input.GetTouch(0);
        touchPosition = camera.ScreenToWorldPoint(touch.position);

        hit = Physics2D.Raycast(touchPosition, Camera.main.transform.forward);
    }

    IEnumerator SetUpNewBall()
    {
        if (!cooldown)
        {
            cooldown = true;
            yield return new WaitForSeconds(0.5f);
            newBall = Instantiate(ballPrefab, gameObject.transform);
            newBall.transform.position = pos;
            newBall.GetComponent<Rigidbody2D>().isKinematic = true;
            ballRigidbody = newBall.GetComponent<Rigidbody2D>();
            ballRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            ballRigidbody.GetComponent<CircleCollider2D>().isTrigger = true;
            cooldown = false;
        }
    }
}
