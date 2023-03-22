using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] private List<PathPoint> _points;
    [SerializeField] private NavMeshAgent _agent;

    private int _indexPoint;
    void Start()
    {
        _points = FindObjectsByType<PathPoint>(FindObjectsSortMode.None).ToList();
        _agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _indexPoint = Random.Range(0,_points.Count);
            _agent.SetDestination(_points[_indexPoint].transform.position);
        }
    }
}
