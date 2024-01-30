using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _spawners;
    [SerializeField] private int _countToSpawn = 30;
    [SerializeField] private float _delayTime = 2;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayTime);

        while(_countToSpawn > 0)
        {
            _spawners[Random.Range(0, _spawners.Length)].SpawnEnemy();
            _countToSpawn--;
            yield return delay;
        }
    }
}