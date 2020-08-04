using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemyItem
{
    public GameObject enemy;
    public int count;
    public float respawn;
    public float firstDelay;
}

public class SpawnController : MonoBehaviour
{
    public Boundary boundary;
    public EnemyItem enemy;

    Queue<GameObject> enemysPool = new Queue<GameObject>();

    Coroutine spawn;

    private void Start()
    {
        spawn = StartCoroutine(Spawn(enemy.enemy, enemy.count, enemy.respawn, enemy.firstDelay));

        for (int i = 0; i < enemy.count; i++)
        {
            var b = Instantiate(enemy.enemy);
            b.SetActive(false);
            enemysPool.Enqueue(b);
        }

        Progress.GameWin += StopSpawn;
        Enemy.ReturnInPool += ReturnInPool;
    }

    private void OnDisable()
    {
        Progress.GameWin -= StopSpawn;
        Enemy.ReturnInPool -= ReturnInPool;
    }

    void ReturnInPool(GameObject _enemy)
    {
        _enemy.SetActive(false);
        enemysPool.Enqueue(_enemy);
    }

    void StopSpawn()
    {
        StopCoroutine(spawn);
    }

    IEnumerator Spawn(GameObject enemy, int count, float respawn, float firstDelay)
    {
        yield return new WaitForSeconds(firstDelay);
        for (int i = 0; i < count; i++)
        {
            var pos = new Vector3(Random.Range(boundary.xMin, boundary.xMax), Random.Range(boundary.yMin, boundary.yMax));

            var b = enemysPool.Dequeue();
            b.transform.position = pos;
            b.SetActive(true);

            yield return new WaitForSeconds(respawn);
        }
    }
}
