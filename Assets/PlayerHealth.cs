using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public static UnityAction<int> SetHeslth;
    public static UnityAction GameOver;

    public int health = 3;

    public void SetDamage()
    {
        health--;
        SetHeslth?.Invoke(health);
        if (health <= 0)
        {
            GameOver?.Invoke();
            Destroy(gameObject);
        }
    }
}
