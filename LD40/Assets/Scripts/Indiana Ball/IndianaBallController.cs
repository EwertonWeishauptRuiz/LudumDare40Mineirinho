using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaBallController : MonoBehaviour {

    public Transform spawnLocation;
    public GameObject ballPrefab;
    public Vector3 ballForce;

    float timer;
    bool started;
    
    // Use this for initialization
    void Start() {
        timer = 1f;
        started = false;
    }

    private void Update()
    {
        if(!started)
        {
            if(timer > 0)
                timer -= Time.deltaTime; 
            else
            {
                started = true;
                StartCoroutine("SpawnBall");
            }
        }
    }

    void Instantiateball() {
        GameObject ball = Instantiate(ballPrefab, spawnLocation.transform.position, Quaternion.Euler(0, 0, 90));
        Rigidbody rbd = ball.GetComponent<Rigidbody>();
        rbd.AddForce(ballForce, ForceMode.Impulse);
    }

    public IEnumerator SpawnBall() {
        while (true) {
            Instantiateball();            
            yield return new WaitForSeconds(1.6f);
        }
    }
}
