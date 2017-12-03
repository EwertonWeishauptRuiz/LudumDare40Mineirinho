using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    ItemPickup pItemPickup;

    public int itemType;
    // itemType == 1 -> gold
    // itemType == 2 -> silver

    private void Awake()
    {
        pItemPickup = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemPickup>();
    }

    private void Start()
    {
        if (itemType != 1 && itemType != 2)
            itemType = 1;
    }

    // Update is called once per frame
    void Update () {
	    	
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pItemPickup.ItemPicked(itemType);
        }
            
    }
}
