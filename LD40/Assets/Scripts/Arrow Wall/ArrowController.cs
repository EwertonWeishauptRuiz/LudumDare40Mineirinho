using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    public ArrowWallBehaviour wallLeft;
    public ArrowWallBehaviour wallRight;
    public bool readyToShoot;	

	void Update () {
        if (wallLeft.active || wallRight.active) {
            readyToShoot = false;
        } else {
            readyToShoot = true;
        }       
	}
}
