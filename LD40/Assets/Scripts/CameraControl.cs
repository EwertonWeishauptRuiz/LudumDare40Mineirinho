using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraControl : MonoBehaviour
{

    public Transform target;
    public float lookSmoth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 6, -8);
    public float xTilt = 10;

    Vector3 destination = Vector3.zero;
    PlayerController charController;
    float rotateVel = 0;

    private void Start()
    {
        SetCameraTarget(target);
    }

    void SetCameraTarget(Transform t)
    {
        target = t;

        if (target != null)
        {
            if (target.GetComponent<PlayerController>())
            {
                charController = target.GetComponent<PlayerController>();
            }
            else
            {
                Debug.Log("Camera target needs char controller");
            }
        }
        else
        {
            Debug.Log("Camera needs target");
        }
    }

    void LateUpdate()
    {
        MoveToTarget();
        LookAtTarget();
    }

    void MoveToTarget()
    {
        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }

    void LookAtTarget()
    {
        float eulerYangle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.localEulerAngles.y, ref rotateVel, lookSmoth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYangle, 0);
    }
}
