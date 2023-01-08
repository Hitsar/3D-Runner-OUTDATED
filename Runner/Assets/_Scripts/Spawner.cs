using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] GameObject[] _prefabObjects;
    [SerializeField] Transform[] _spawner;
    [SerializeField] float _secondForSpawn;
    private float _time = 0;

    private void Start()
    {
        Initialized(_prefabObjects);
        StartCoroutine(SecondsSpawn());
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _secondForSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _time = 0;

                int spawnPointNumber = Random.Range(0, _spawner.Length);

                SetEnemy(enemy, _spawner[spawnPointNumber].position);
            }
        }

        if (_secondForSpawn <= 0.3)
        {
            StopCoroutine(SecondsSpawn());
        }

    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
    private IEnumerator SecondsSpawn()
    {
        var seconds = new WaitForSeconds(5);
        _secondForSpawn -= 0.1f;
        yield return seconds;
    }
}
