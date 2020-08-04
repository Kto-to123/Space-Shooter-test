using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float reload = 1f;
    public GameObject bullet;
    public Transform weaponPoint;
    public AudioSource audio;

    Queue<GameObject> currentBullets = new Queue<GameObject>();

    bool played = true;

    private void Start()
    {
        StartCoroutine(shoot());

        Progress.GameWin += GameOver;
        PlayerHealth.GameOver += GameOver;
        Bullet.reload += Reload;

        for (int i = 0; i < 10; i++)
        {
            var b = Instantiate(bullet);
            b.SetActive(false);
            currentBullets.Enqueue(b);
        }
    }

    private void OnDestroy()
    {
        Progress.GameWin -= GameOver;
        PlayerHealth.GameOver -= GameOver;
        Bullet.reload -= Reload;
    }

    public void GameOver()
    {
        played = false;
    }

    void Reload(GameObject b)
    {
        b.SetActive(false);
        currentBullets.Enqueue(b);
    }

    IEnumerator shoot()
    {
        while (played)
        {
            if (currentBullets.Count > 0)
            {
                var b = currentBullets.Dequeue();
                b.transform.position = weaponPoint.position;
                b.SetActive(true);

                audio.Play();
            }
            yield return new WaitForSecondsRealtime(reload);
        }
    }
}
