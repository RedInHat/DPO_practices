using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private FieldOfView _fieldOfview;
    private NavMeshAgent _meshAgent;
    void Start()
    {
        _fieldOfview = GetComponent<FieldOfView>();
        _meshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(_fieldOfview.canSeePlayer)
        {
            transform.LookAt(_fieldOfview.playerRef.transform.position);
            _meshAgent.SetDestination(_fieldOfview.playerRef.transform.position);
        }
    }
}
