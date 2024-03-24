using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float offset;
    [SerializeField] float smoothSpeed = 5;
    [SerializeField] Vector3 minValues, maxValues;

    void FixedUpdate()
    {
        follow();
    }

    public void follow() {
        Vector3 desiredPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        if(target.transform.localScale.x > 0.0f) {
            desiredPosition = new Vector3(desiredPosition.x + offset, desiredPosition.y, desiredPosition.z);
        } else if(target.transform.localScale.x < 0.0f) {
            desiredPosition = new Vector3(desiredPosition.x - offset, desiredPosition.y, desiredPosition.z);
        }
        
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