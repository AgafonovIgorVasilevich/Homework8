using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private float _speed;

    private int _nextPoint = 0;

    public IEnumerator Patrol(Vector3[] wayPoints)
    {
        bool isPatrol = wayPoints.Length > 0;
        _animator.Walk();

        while (isPatrol)
        {
            if (transform.position == wayPoints[_nextPoint])
            {
                _nextPoint = (_nextPoint + 1) % wayPoints.Length;
                transform.LookAt(wayPoints[_nextPoint]);
            }

            transform.position = Vector3.MoveTowards(transform.position, wayPoints[_nextPoint], _speed * Time.deltaTime);
            yield return null;
        }

        _animator.Stay();
    }
}