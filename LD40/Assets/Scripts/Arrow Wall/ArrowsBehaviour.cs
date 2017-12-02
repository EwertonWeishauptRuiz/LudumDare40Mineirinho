using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsBehaviour : MonoBehaviour {

<<<<<<< HEAD
    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Wall" || col.gameObject.tag == "Player") {
            print("Hit Arrow");
            Destroy(gameObject);
        }
    }
=======

>>>>>>> b61fdcc641046a2515da0eb4ad9e3021e3d4b5b0
}
