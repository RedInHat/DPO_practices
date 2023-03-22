using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Material _material;
    private Color _color;


    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _color = _material.color;
    }
    public void GetDamage(float damage)
    {
        _color.r = Mathf.Clamp(_color.r + damage, 0, 1);
        _color.g = Mathf.Clamp(_color.g + damage, 0, 1);
        _color.b = Mathf.Clamp(_color.b + damage, 0, 1);

        _material.color = _color;
        transform.Find("Face").GetComponent<MeshRenderer>().material.color= _color;
    }
}
