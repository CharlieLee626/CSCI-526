using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 8f;
    public float maxZoom = 20f;
    public float yawSpeed = 100f;

    private float currentZoom = 15f;
    private float pitch = 2f;
    private float currentYaw = 0f;

    public Joystick joystick;

    private void Update()
    {
        if(joystick.Vertical >= .5f || joystick.Vertical <= -0.5f)
        {
            currentZoom -= joystick.Vertical * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        }

        if(joystick.Horizontal >= .8f || joystick.Horizontal <= -0.8f)
        {
            currentYaw -= joystick.Horizontal * yawSpeed * Time.deltaTime;
        }
        
    }


    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
