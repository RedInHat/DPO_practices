using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    [SerializeField] private List<GameObject> _exits;
    [SerializeField] private int _openExit;

    private void OnTriggerEnter(Collider other)
    {
        _exits = GameObject.FindGameObjectsWithTag("Exit").ToList();
        _openExit = Random.Range(0, _exits.Count);

        _exits[_openExit].GetComponent<Renderer>().enabled = false;

        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
    }
}
