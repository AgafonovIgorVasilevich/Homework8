using System.Linq;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    public Vector3[] GetWayPoints()
    {
        return _wayPoints.Select(wayPoint => wayPoint.position).ToArray();
    }
}
