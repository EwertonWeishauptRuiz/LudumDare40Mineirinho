using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour {    
 
    public float distTarget;
    Vector3 initPos;
    Vector3 target;
    public float timeToTarget;
    float timer;
    float time;
    float distanceToTarget, distanceCovered, fraction;
    public bool advance, backward;
    Vector3 velocity;


    void Start() {
        velocity = Vector3.zero;
        initPos = transform.position;
        target = new Vector3(transform.position.x + distTarget, transform.position.y, transform.position.z);

    }

    void Update() {
        if (advance) {
            MoveForward();
            CheckArrival(target);
        }

        if(backward) {
            MoveBackward();
            CheckArrival(initPos);
            if (backward && advance) {
                advance = false;                
            }   
        }
        
    }

    void CheckArrival(Vector3 targetPos) {
        if (Vector3.Distance(transform.position, targetPos) < 0.1f) {
                backward = false;
                advance = false;
        }
    }

    void MoveForward() {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, timeToTarget);
    }

    void MoveBackward() {
        transform.position = Vector3.SmoothDamp(transform.position, initPos, ref velocity, timeToTarget);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth pHealth = collision.gameObject.GetComponent<PlayerHealth>();
            pHealth.TakeHit();
        }
    }
}
