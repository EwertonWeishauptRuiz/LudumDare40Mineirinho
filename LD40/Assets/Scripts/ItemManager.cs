using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public int carryingGold;
    public int carryingSilver;
    public int score;
    int carryingTotal;
    PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        carryingGold = 0;
        carryingSilver = 0;
        carryingTotal = 0;
        score = 0;
    }

    // itemTypes> 1 == gold, 2 == silver
    public void ItemPicked(int itemType)
    {
        if (itemType == 1)
        {
            carryingGold += 1;
        }
        if (itemType == 2)
        {
            carryingSilver += 1;
        }

        playerController.SpeedDown();
        carryingTotal += 1;
        
    }

    public void DropPoint()
    {
        score += carryingGold * 20;
        carryingGold = 0;
        score += carryingSilver * 10;
        carryingSilver = 0;
        carryingTotal = 0;
        playerController.ResetSpeed();
    }
}
