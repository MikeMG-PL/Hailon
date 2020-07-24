using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    static bool isPaused = false;
    static bool isPlaying = true;

    public enum Notification
    {
        GamePaused,
        GamePlaying
    };

    public static bool IsPaused()
    {
        return isPaused;
    }

    public static bool IsPlaying()
    {
        return isPlaying;
    }

    public static void Notify(Notification notification)
    {
        switch (notification)
        {
            case Notification.GamePaused:
                isPaused = true;
                isPlaying = false;
                break;

            case Notification.GamePlaying:
                isPaused = false;
                isPlaying = true;
                break;
        }
    }
}
