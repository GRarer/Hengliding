using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetPosition;
    private Vector3 velocity = Vector3.zero;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(offsetPosition);
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f, Mathf.Infinity, Time.fixedDeltaTime);
        transform.LookAt(target, target.up);
    }
}
