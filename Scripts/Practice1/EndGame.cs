using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    Rigidbody platform;

    private void OnTriggerEnter(Collider other)
    {
        platform.isKinematic= false;
    }
}
