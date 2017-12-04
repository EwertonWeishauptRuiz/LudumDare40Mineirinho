using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {
    
    public SpikesBehaviour[] doorBehaviour;
    bool allAdvanced;
    public float holdTime;
    float time;

    bool step;
	// Use this for initialization
	void Start () {
        print(doorBehaviour.Length);
        StartCoroutine("AdvanceWalls");
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(allAdvanced) {
            holdTime -= Time.deltaTime;
            if (holdTime < 0) {
                StartCoroutine("RetreatWalls");
            }
        }
	}

    IEnumerator AdvanceWalls() {
        int i = 0;
        while (true) {
            doorBehaviour[i].advance = true;
            i++;
            if(i > doorBehaviour.Length - 1) {
                StopCoroutine("AdvanceWalls");
                allAdvanced = true;               
            }            
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator RetreatWalls() {
        int i = 0;
        while (true) {
            doorBehaviour[i].backward = true;
            i++;
            if (i > doorBehaviour.Length - 1) {
                StopCoroutine("RetreatWalls");
                allAdvanced = true;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            step = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player") {
            step = false;
        }
    }
}
