using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraControl : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.3f;
    Vector3 velocity = Vector3.zero;
    

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}
