using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    static bool isPaused = false;
    static bool isPlaying = true;
    static bool isPlayerKilled = false;
    static bool isPlayerAlive = true;

    public enum Notification
    {
        GamePaused,
        GamePlaying,
        PlayerKilled,
        PlayerAlive
    };

    private void Awake()
    {
        Notify(Notification.PlayerAlive);
        Notify(Notification.GamePlaying);
    }

    public static bool IsPaused()
    {
        return isPaused;
    }

    public static bool IsPlaying()
    {
        return isPlaying;
    }

    public static bool IsPlayerKilled()
    {
        return isPlayerKilled;
    }

    public static bool IsPlayerAlive()
    {
        return isPlayerAlive;
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

            case Notification.PlayerKilled:
                isPlayerKilled = true;
                isPlayerAlive = false;
                break;

            case Notification.PlayerAlive:
                isPlayerKilled = false;
                isPlayerAlive = true;
                break;
        }
    }
}
