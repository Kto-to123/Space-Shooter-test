using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public static UnityAction<GameObject> reload;

    public float speed = 0.1f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        reload?.Invoke(gameObject);
    }
}
