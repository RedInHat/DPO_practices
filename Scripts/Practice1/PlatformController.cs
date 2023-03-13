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
        //�������� ������ rotation ��������� V3 = (X,Y,Z)
        startRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //�������� ������ ��� X
        rotation.x += Input.GetAxis("Horizontal") * speedRotation * Time.deltaTime;

        //�������� ������ ��� Z
        rotation.z += Input.GetAxis("Vertical") * speedRotation * Time.deltaTime; 

        // �������� �������� � �������� �� ������� ��� ���������
        rotation.x = Mathf.Clamp(rotation.x, -limitAngle, limitAngle);
        rotation.z = Mathf.Clamp(rotation.z, -limitAngle, limitAngle);

        //������� ���������
        transform.localEulerAngles = startRotation + rotation;

    }
}
