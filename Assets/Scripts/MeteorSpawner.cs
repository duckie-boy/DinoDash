using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float Xoffset;
    [SerializeField] float height = 13.5f;
    [SerializeField] GameObject meteorDaddy;

    void Start() {
        SpawnMeteor();
    }
    void FixedUpdate()
    {
        follow();
    }

    public void follow() {
        Vector3 desiredPosition = new Vector3(target.transform.position.x, height, transform.position.z);
        if(target.transform.localScale.x > 0.0f) {
            desiredPosition = new Vector3(desiredPosition.x + Xoffset, height, desiredPosition.z);
        } else if(target.transform.localScale.x < 0.0f) {
            desiredPosition = new Vector3(desiredPosition.x - Xoffset, height, desiredPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position,desiredPosition,Time.deltaTime);
    }
    
    void SpawnMeteor() {
        StartCoroutine(SpawnMeteorRoutine());
        IEnumerator SpawnMeteorRoutine() {
            while(true) {
                SpawnMeteorRandom();
                yield return new WaitForSeconds(1);
                SpawnMeteorRandom();
                yield return new WaitForSeconds(1);
                SpawnMeteorRandom();
                yield return new WaitForSeconds(1);
                SpawnMeteorRandom();
                yield return new WaitForSeconds(1);
                SpawnMeteorRandom();
                yield return new WaitForSeconds(1);
                SpawnMeteorRandom();
                yield return new WaitForSeconds(1);
            }
        }
    }
    void SpawnMeteorRandom() {
        GameObject newMeteor = Instantiate(meteorDaddy, new Vector3((Random.Range(transform.position.x-15,transform.position.x+15)), (Random.Range(13,15)), 0), Quaternion.identity);
        Destroy(newMeteor,15);
    }
}
