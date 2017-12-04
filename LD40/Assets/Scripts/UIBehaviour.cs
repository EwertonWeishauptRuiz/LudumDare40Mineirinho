using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBehaviour : MonoBehaviour {
    PlayerHealth healthScript;
    Text hpLeft;

 void Start () {
    hpLeft = GetComponent<Text>();
    healthScript = GameObject.FindObjectOfType<PlayerHealth>();
    }
    void Update()    {
        
        hpLeft.text = "x" + healthScript.health;
    }
}
