using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject body;
    [SerializeField] LayerMask ground;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpForce = 20;
    [SerializeField] float jumpOffset = -0.75f;
    [SerializeField] float jumpRadius = 0.1f;
    [SerializeField] List<AnimationHandler> animationStateChangers;
    
    void Awake(){

        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }
    public void Move(Vector3 direction) {
        
        Vector3 currentVelocity = Vector3.zero;
        currentVelocity = new Vector3(0, rb.velocity.y, 0);
        direction.y = 0;
        rb.velocity = currentVelocity + direction * speed;
        if(rb.velocity.x < 0){
            body.transform.localScale = new Vector3(-1.5f,1.5f,1.5f);
        }else if(rb.velocity.x > 0){
            body.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        }
        if(direction != Vector3.zero) {
            foreach(AnimationHandler asc in animationStateChangers) {
                asc.ChangeAnimationState("TriceratopsWalk", speed);
            }
        } else {
            foreach(AnimationHandler asc in animationStateChangers) {
                asc.ChangeAnimationState("Idle");
            }
        }
        
    }

    public void Jump() {
        if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0, jumpOffset, 0), jumpRadius, ground).Length > 0) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
       //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
