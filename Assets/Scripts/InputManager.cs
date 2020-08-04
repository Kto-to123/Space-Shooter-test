using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputManager instance;

    public Joystick joystick;

    private void Awake()
    {
        instance = this;
    }

    public static float GetHorizontal()
    {
        var kay = Input.GetAxis("Horizontal");
        var joy = instance.joystick.Horizontal;
        return joy != 0 ? joy : kay;
    }

    public static float GetVertical()
    {
        var kay = Input.GetAxis("Vertical");
        var joy = instance.joystick.Vertical;
        return joy != 0 ? joy : kay;
    }
}
