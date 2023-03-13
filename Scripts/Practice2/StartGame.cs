using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> _platforms;
    [SerializeField] private int _activePlatform;

    private void Start()
    {
        _platforms = GameObject.FindGameObjectsWithTag("Platform").ToList();
        _activePlatform = Random.Range(0, _platforms.Count);

        _platforms[_activePlatform].GetComponent<BoxCollider>().isTrigger = true;
        _platforms[_activePlatform].AddComponent<TriggerPlatform>();
    }
}
