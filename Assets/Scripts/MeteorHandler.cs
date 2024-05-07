using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHandler : MonoBehaviour
{
    [SerializeField] AudioSource meteorSound;
    void OnTriggerEnter2D(Collider2D other) {
        meteorSound.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        Destroy(this.gameObject,1);
    }
}
