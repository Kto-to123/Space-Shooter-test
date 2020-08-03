using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.1f;

    private void Awake()
    {
        Progress.GameWin += Destroy;
    }

    private void OnDestroy()
    {
        Progress.GameWin -= Destroy;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerHealth>();
        if (player != null) player.SetDamage();
        Destroy(gameObject);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
