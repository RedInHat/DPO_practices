using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private NavMeshAgent _agent;
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        _agent.transform.LookAt(_target.transform);
        _agent.SetDestination(_target.transform.position);
    }
}
