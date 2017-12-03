using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public Transform target;

    int moveSpeed = 2;
    float minDistance = .5f;
    int maxDistance = 5;

	void Start () {
		
	}
	
	void Update () {
        transform.LookAt(target);

        if(Vector3.Distance(transform.position, target.position) >= minDistance) {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;            
        }
        if (Vector3.Distance(transform.position, target.position) > maxDistance) {
            transform.position += transform.forward * (moveSpeed + 5) * Time.deltaTime;            
        }
    }
}
