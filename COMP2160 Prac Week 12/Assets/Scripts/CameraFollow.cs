using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Rigidbody targetRigidbody;

    public float followDistance;

    public float smoothing = 0.5f;
    private Vector3 smoothDir = Vector3.zero;

    void Start()
    {
        targetRigidbody = target.GetComponent<Rigidbody>();

        Vector3 position = transform.position;
        position.x = target.position.x;        
        position.z = target.position.z;
        transform.position = position;
    }

    void Update()
    {
        Vector3 position = transform.position;
        position.x = target.position.x;        
        position.z = target.position.z;

        Vector3 dir = targetRigidbody.velocity;
        dir.y = 0;
        smoothDir = Vector3.Lerp(smoothDir, -dir * followDistance, smoothing);

        position += smoothDir;

        transform.position = position;

        
    }
}
