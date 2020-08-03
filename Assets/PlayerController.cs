using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    public Boundary boundary;
    public InputManager input;

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(input.GetHorizontal() * speed, input.GetVertical() * speed, 0);

        transform.Translate(move);
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax),
            0f
        );
    }
}
