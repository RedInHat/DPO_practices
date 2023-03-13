using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class TriggerSpotlight : MonoBehaviour
{
    [SerializeField] private List<Light> spotlights;
    [SerializeField] private Transform player;

    private bool _isDetected;
    private Vector3 _colorDetection;

    void Start()
    {
        _isDetected = false;

        //pastel red
        _colorDetection = new Vector3(239, 118, 99);
        _colorDetection /= 255;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isDetected = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spotlights = FindObjectsByType<Light>(FindObjectsSortMode.None).ToList();
        spotlights = spotlights.Where(spot => (spot.type == LightType.Spot)).ToList();

        foreach (Light spot in spotlights)
        { 
            spot.color = new Color(_colorDetection.x, _colorDetection.y, _colorDetection.z);
            spot.intensity = 2;
            spot.transform.Find("Trigger").GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    void Update()
    {
        if (_isDetected)
        {
            foreach (Light spot in spotlights)
            {
                spot.transform.LookAt(player);
            }
        }
    }
}
