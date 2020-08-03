using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Joystick joystick;

    public float GetHorizontal()
    {
        var kay = Input.GetAxis("Horizontal");
        var joy = joystick.Horizontal;
        return joy != 0 ? joy : kay;
    }

    public float GetVertical()
    {
        var kay = Input.GetAxis("Vertical");
        var joy = joystick.Vertical;
        return joy != 0 ? joy : kay;
    }
}
