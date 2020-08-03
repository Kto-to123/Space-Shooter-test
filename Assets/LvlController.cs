using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyItem
{
    public GameObject enemy;
    public int count;
    public float respawn;
    public float firstDelay;
}

public class LvlController : MonoBehaviour
{
    public Boundary boundary;
    public List<EnemyItem> Enemys;

    Coroutine sp;

    private void Start()
    {
        foreach (var enemy in Enemys)
        {
            sp = StartCoroutine(spawn(enemy.enemy, enemy.count, enemy.respawn, enemy.firstDelay));
        }

        Progress.GameWin += StopSpawn;
    }

    void StopSpawn()
    {
        StopCoroutine(sp);
    }

    IEnumerator spawn(GameObject enemy, int count, float respawn, float firstDelay)
    {
        yield return new WaitForSeconds(firstDelay);
        for (int i = 0; i < count; i++)
        {
            var pos = new Vector3(Random.Range(boundary.xMin, boundary.xMax), Random.Range(boundary.yMin, boundary.yMax));
            Instantiate(enemy, pos, Quaternion.identity);
            yield return new WaitForSeconds(respawn);
        }
    }
}
