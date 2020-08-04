using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public static UnityAction<GameObject> ReturnInPool;

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
        ReturnInPool?.Invoke(gameObject);
    }

    private void Destroy()
    {
        ReturnInPool?.Invoke(gameObject);
    }
}
