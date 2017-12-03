using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    ItemManager pItemManager;

    public int itemType;
    // itemType == 1 -> gold
    // itemType == 2 -> silver

    private void Awake()
    {
        pItemManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemManager>();
    }

    private void Start()
    {
        if (itemType != 1 && itemType != 2)
            itemType = 1;
    }

    // Update is called once per frame
    void Update () {
	    	
	}

    private void OnMouseDown()
    {
        float dist = Vector3.Distance(transform.position, pItemManager.transform.position);
        if (dist < 2.5f)
        {
            pItemManager.ItemPicked(itemType);
            Debug.Log("Picked");
        }
        else
        {
            Debug.Log("Too far");
        }
    }
}
