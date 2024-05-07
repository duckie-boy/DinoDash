using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dinosaur : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject body;
    [SerializeField] LayerMask ground;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float mushSpeed = 3.5f;
    [SerializeField] float jumpForce = 20;
    [SerializeField] float jumpOffset = -0.75f;
    [SerializeField] float jumpRadius = 0.1f;
    [SerializeField] Vector3 checkpoint = new Vector3(-8.5f,-2.44f,0);
    [SerializeField] float scale = 1.0f;
    [SerializeField] List<AnimationHandler> animationStateChangers;
    Vector3 respawnPoint;
    public GameObject VoidDetector;
    public GameObject EndDetector;
    public LifeCounter lives;
    public bool hasCheckPoint = false;
    public GameObject Spawnable;
    GameObject mushroom;
    public GameObject blockHider;
    GameObject hidden;
    [SerializeField] AudioSource midpointSound;
    [SerializeField] AudioSource endLevelSound;
    [SerializeField] AudioSource music;
    public int nextSceneLoad;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        respawnPoint = transform.position;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void Move(Vector3 direction) {
        
        Vector3 currentVelocity = Vector3.zero;
        currentVelocity = new Vector3(0, rb.velocity.y, 0);
        direction.y = 0;
        rb.velocity = currentVelocity + direction * speed;
        if(rb.velocity.x < 0){
            body.transform.localScale = new Vector3(-scale,scale,1.0f);
        }else if(rb.velocity.x > 0){
            body.transform.localScale = new Vector3(scale,scale,1.0f);
        }

        if(direction != Vector3.zero) {
            foreach(AnimationHandler asc in animationStateChangers) {
                asc.ChangeAnimationState("Walk", speed);
            }
        } else {
            foreach(AnimationHandler asc in animationStateChangers) {
                asc.ChangeAnimationState("Idle");
            }
        }

        VoidDetector.transform.position = new Vector2(transform.position.x, VoidDetector.transform.position.y);
    }

    public void Jump() {
        if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0, jumpOffset, 0), jumpRadius, ground).Length > 0) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Void") {
            lives.LoseLife();
            transform.position = respawnPoint;
        }
        else if(collision.tag == "Midpoint") {
            respawnPoint = transform.position;
            if(hasCheckPoint == false) {
                hasCheckPoint = true;
                midpointSound.Play();
                lives.ResetLife();
            }
            Color tmp = collision.GetComponent<SpriteRenderer>().color;
            collision.GetComponent<SpriteRenderer>().color = new Color(tmp.r, tmp.g, tmp.b, 255);
        }
        else if(collision.tag == "Egg") {
            if(nextSceneLoad > PlayerPrefs.GetInt("levelAt")) {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
            music.Pause();
            Time.timeScale = 0f;
            endLevelSound.Play();
            EndDetector.SetActive(true);
        }
        else if(collision.tag == "Thorns") {
            lives.LoseLife();
        }
        else if(collision.tag == "Interactable") {
            Vector3 InteractableSpawnPoint = new Vector3(collision.offset.x, collision.offset.y+1, transform.position.z);
            mushroom = Instantiate(Spawnable, InteractableSpawnPoint, Quaternion.identity);
            mushroom.GetComponent<Rigidbody2D>().velocity = mushroom.transform.right * mushSpeed;
            Destroy(mushroom, 15);
            hidden = Instantiate(blockHider, collision.offset, Quaternion.identity);
            collision.isTrigger = false;
        }
        else if(collision.tag == "Mushroom") {
            Destroy(mushroom);
            lives.AddLife();
        }
        else if(collision.tag == "Meteor") {
            lives.LoseLife();
        }
    }
}