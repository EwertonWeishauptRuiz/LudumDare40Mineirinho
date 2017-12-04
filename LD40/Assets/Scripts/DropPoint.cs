using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoint : MonoBehaviour {

    public int dropType;

    ItemManager pItemManager;
    bool canDrop;

    private void Awake()
    {
        pItemManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemManager>();
    }

    private void Start()
    {
        canDrop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canDrop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canDrop = false;
        }
    }

    private void OnMouseDown()
    {
        if(canDrop)
        {
            pItemManager.DropPoint(dropType);
            Debug.Log("Droped");
        }
        else
        {
            Debug.Log("Too far");
        }
    }
}
