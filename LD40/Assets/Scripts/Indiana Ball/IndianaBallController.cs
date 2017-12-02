using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaBallController : MonoBehaviour {

    public Transform spawnLocation;
    public GameObject ballPrefab;
    
    // Use this for initialization
    void Start() {
        StartCoroutine("SpawnBall");
    }
    
    void Instantiateball() {
        GameObject ball = Instantiate(ballPrefab, spawnLocation.transform.position, Quaternion.Euler(0, 0, 90));
        Rigidbody rbd = ball.GetComponent<Rigidbody>();
        rbd.velocity = new Vector3(0, 0, -20);
    }

    public IEnumerator SpawnBall() {
        while (true) {
            Instantiateball();            
            yield return new WaitForSeconds(2f);
        }
    }
}
