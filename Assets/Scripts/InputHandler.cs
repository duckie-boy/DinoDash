using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] Dinosaur dino;
    void Update()
    {
        Vector3 input = Vector3.zero;

        if(Input.GetKey(KeyCode.A)) {
            input.x += -1;
        }
        if(Input.GetKey(KeyCode.D)) {
            input.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            dino.Jump();
        }

        dino.Move(input);
    }
    
}
