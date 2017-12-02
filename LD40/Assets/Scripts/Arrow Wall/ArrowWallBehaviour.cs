using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWallBehaviour : MonoBehaviour {

    public Transform spawnPlace;
    Vector3 mySpawn;
    public GameObject arrow;
    public bool step;
    public bool reversePosition;
	
	void Start () {
        mySpawn = spawnPlace.transform.position;        
    }

    void Update() {
        if (step) {
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
    
    IEnumerator ShootArrows () {
        int i = 0;
        while (true){ 
            ArrowLocation();
            print(mySpawn);
            i++;
            if(i > 19) {
                StopCoroutine("ShootArrows");
                mySpawn = spawnPlace.transform.position;
            }
            yield return new WaitForSeconds(0.2f);       
        }
   }
}


