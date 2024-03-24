using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed = 5;
    [SerializeField] Vector3 minValues, maxValues;

    void FixedUpdate()
    {
        follow();
    }

    public void follow() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 bounds = new Vector3 (
            Mathf.Clamp(desiredPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(desiredPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(desiredPosition.z, minValues.z, maxValues.z)
        );

        transform.position = Vector3.Lerp(transform.position,bounds,smoothSpeed*Time.deltaTime);
    }
    public void AssignTarget(Transform newTarget){
        target = newTarget;
    }
}