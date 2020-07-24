using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static bool movementAllowed = true;

    public enum MovementAllowed
    {
        Yes,
        No
    };

    public static bool IsMovementAllowed()
    {
        return movementAllowed;
    }

    public static void AllowMovement(MovementAllowed movement)
    {
        switch(movement)
        {
            case MovementAllowed.Yes:
                movementAllowed = true;
                break;

            case MovementAllowed.No:
                movementAllowed = false;
                break;
        }
    }
}
