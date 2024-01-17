using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField] [Range(20, 90)] float defaultPitch = 40;
    [SerializeField] [Range(2, 8)] float distance = 5;
    [SerializeField] [Range(0.1f, 2.0f)] float Sensitivity = 1;

    float yaw = 0;
    float pitch = 0;

    private void Start()
    {
        pitch = defaultPitch;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) yaw += Input.GetAxis("Mouse X") * Sensitivity;
        if (Input.GetKey(KeyCode.Mouse0)) pitch += Input.GetAxis("Mouse Y") * Sensitivity;

        Quaternion qYaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qPitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qYaw * qPitch;

        transform.position = target.position + (rotation * Vector3.back * distance);
        transform.rotation = rotation;
    }
}
