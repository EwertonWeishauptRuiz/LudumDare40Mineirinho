using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsBehaviour : MonoBehaviour {

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Wall" || col.gameObject.tag == "Player") {
            print("Hit Arrow");
            Destroy(gameObject);
        }
    }

}
