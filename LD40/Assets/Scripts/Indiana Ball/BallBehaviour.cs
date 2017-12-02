using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    public float lifeTime = 5f;
    
	// Update is called once per frame
	void Update () {
        if(lifeTime <= 0) {
            Destroy(gameObject);
        }		
        lifeTime -= Time.deltaTime;        
	}
}
