using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float reload = 1f;
    public GameObject Bullet;
    public Transform weaponPoint;

    private void Start()
    {
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {
        while (true)
        {
            Instantiate(Bullet, weaponPoint.position, weaponPoint.rotation);
            yield return new WaitForSecondsRealtime(reload);
        }
    }
}
