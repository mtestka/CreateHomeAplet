using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float minFov = 15f;
    public float maxFov = 90f;
    float sensitivity = 10f;
    public GameObject cube;
    public Transform center;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius = 5.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    void Start()
    {
        center = cube.transform;
        transform.position = (transform.position - center.position).normalized * radius + center.position;
    }

    // Update is called once per frame
    void Update()
    {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        /*desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);*/
    }
}
