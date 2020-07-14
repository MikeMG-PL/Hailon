using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour
{
    public SpriteRenderer background;

    private void Awake()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = background.bounds.size.x / background.bounds.size.y;

        if (screenRatio >= targetRatio)
            GetComponent<Camera>().orthographicSize = background.bounds.size.y * 0.5f;

        else
        {
            float differenceInSize = targetRatio / screenRatio;
            GetComponent<Camera>().orthographicSize = background.bounds.size.y * 0.5f * differenceInSize;
        }
    }
}
