using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWallBehaviour : MonoBehaviour {

    public Transform spawnPlace;
    Vector3 mySpawn;
    public GameObject arrow;
    public bool step;
    public bool reversePosition;

    public bool active;

    public ArrowController arrowController;
	
	void Start () {
        mySpawn = spawnPlace.transform.position;        
    }

    void Update() {
        if (step && !active && arrowController.readyToShoot) {
            StartCoroutine("ShootArrows");
            step = false;            
        }
    }

    void ArrowLocation() {
        GameObject arrowClone = Instantiate(arrow, mySpawn, Quaternion.Euler(0,0,90));
        Rigidbody rbd = arrowClone.GetComponent<Rigidbody>();
        rbd.AddForce(-transform.right * 500);

        if(reversePosition)
            mySpawn.z += 0.500f;
        else
            mySpawn.z -= 0.500f;
    }
    
    public IEnumerator ShootArrows () {
        int i = 0;
        while (true){
            active = true;
            
            ArrowLocation();            
            i++;
            if(i > 19) {
                StopCoroutine("ShootArrows");
                active = false;
                mySpawn = spawnPlace.transform.position;
            }
            yield return new WaitForSeconds(0.2f);       
        }
   }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            step = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player") {
            step = false;
        }
    }
}


