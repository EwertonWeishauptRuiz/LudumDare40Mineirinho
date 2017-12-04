using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    ItemManager pItemManager;
    Material material;
    public int itemType;

    public AudioClip hitMine;
    AudioSource audiosorce;
    // itemType == 1 -> gold
    // itemType == 2 -> silver

    private void Awake()
    {
        pItemManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemManager>();
        material = GetComponent<Renderer>().material;
        audiosorce = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (itemType != 1 && itemType != 2)
            itemType = 1;
    }

    // Update is called once per frame
    void Update () {
	    	
	}

    void OnMouseEnter() {
        material.color = Color.yellow;
    }

    void OnMouseExit() {
        material.color = Color.white;
    }

    void OnMouseUp() {
        material.color = Color.yellow;
    }

    private void OnMouseDown()
    {
        float dist = Vector3.Distance(transform.position, pItemManager.transform.position);
        if (dist < 2.5f)
        {
            pItemManager.ItemPicked(itemType);
            Debug.Log("Picked");
            material.color = Color.green;
            audiosorce.PlayOneShot(hitMine, 0.1f);
        }
        else
        {
            Debug.Log("Too far");
            material.color = Color.red;
        }
    }
}
