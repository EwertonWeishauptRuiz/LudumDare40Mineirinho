using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {
    
    public SpikesBehaviour[] doorBehaviour;
    public float holdTime;

    float timer;
    bool allAdvanced;
    bool allRetreated;

	// Use this for initialization
	void Start () {
        print(doorBehaviour.Length);
        allAdvanced = false;
        allRetreated = true;
        timer = holdTime;
	}
	
	// Update is called once per frame
	void Update () {

        if(timer <= 0 && allRetreated)
        {
            StartCoroutine("AdvanceWalls");
        }
        else if ( timer <= 0 && allAdvanced)
        {
            StartCoroutine("RetreatWalls");
        }

        if (allAdvanced || allRetreated)
        {
            timer -= Time.deltaTime;
        }
	}

    IEnumerator AdvanceWalls() {
        allAdvanced = false;
        allRetreated = false;
        int i = 1;
        while (true) {
            doorBehaviour[i-1].advance = true;
            doorBehaviour[doorBehaviour.Length - i].advance = true;
            i++;
            if(i > doorBehaviour.Length / 2 + 1) {
                StopCoroutine("AdvanceWalls");
                allAdvanced = true;
                allRetreated = false;
                timer = holdTime;
            }            
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator RetreatWalls() {
        allAdvanced = false;
        allRetreated = false;
        int i = 1;
        while (true) {
            doorBehaviour[i-1].backward = true;
            doorBehaviour[doorBehaviour.Length - i].backward = true;
            i++;
            if (i > doorBehaviour.Length / 2  + 1) {
                StopCoroutine("RetreatWalls");
                allAdvanced = false;
                allRetreated = true;
                timer = holdTime;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
