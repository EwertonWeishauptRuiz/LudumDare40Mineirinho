using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public int score;
    PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        score = 0;
    }

    // itemTypes> 1 == gold, 2 == silver
    public void ItemPicked(int itemType)
    {
        if (itemType == 1)
        {
            score += 20;
            playerController.SpeedDown();
        }
            

    }
}
