using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildGrabber : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Dinosaur>() != null) {
            other.transform.parent = this.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.GetComponent<Dinosaur>() != null) {
            other.transform.parent = null;
        }
    }
}
