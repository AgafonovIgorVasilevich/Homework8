using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private TargetPoint _targetPoint;
    [SerializeField] private Enemy _enemyPrototype;

    private Enemy _spawnedEnemy;
    private Vector3[] _wayPoints;

    private void Awake()
    {
        _wayPoints = _targetPoint.GetWayPoints();
        transform.LookAt(_wayPoints[0]);
    }

    public void SpawnEnemy()
    {
        _spawnedEnemy = Instantiate(_enemyPrototype, transform.position, transform.rotation);
        StartCoroutine(_spawnedEnemy.Patrol(_wayPoints));
    }
}