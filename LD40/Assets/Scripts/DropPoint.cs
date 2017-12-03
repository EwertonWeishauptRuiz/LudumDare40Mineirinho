using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoint : MonoBehaviour {

    ItemManager pItemManager;

    private void Awake()
    {
        pItemManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pItemManager.DropPoint();
        }
    }
}
