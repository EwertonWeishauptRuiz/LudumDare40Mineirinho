using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBehaviour : MonoBehaviour {
    int health;
    Text hpLeft;

 void Start () {
        hpLeft.text = GetComponent<Text>().text;
    health = GameObject.FindObjectOfType<PlayerHealth>().health;
    }
    void Update()    {
        hpLeft.text = "x" + health;
    }
}
