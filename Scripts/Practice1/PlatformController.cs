using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    
    Vector3 rotation;
    Vector3 startRotation;
    float limitAngle = 20f;
    float speedRotation = 20f;
    // Start is called before the first frame update
    void Start()
    {
        //получаем вектор rotation платформы V3 = (X,Y,Z)
        startRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //вращение вокруг оси X
        rotation.x += Input.GetAxis("Horizontal") * speedRotation * Time.deltaTime;

        //вращение вокруг оси Z
        rotation.z += Input.GetAxis("Vertical") * speedRotation * Time.deltaTime; 

        // ѕриводим вращение к значению из нужного нам диапазона
        rotation.x = Mathf.Clamp(rotation.x, -limitAngle, limitAngle);
        rotation.z = Mathf.Clamp(rotation.z, -limitAngle, limitAngle);

        //вращаем платформу
        transform.localEulerAngles = startRotation + rotation;

    }
}
