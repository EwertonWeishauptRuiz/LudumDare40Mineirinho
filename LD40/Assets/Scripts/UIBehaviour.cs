using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBehaviour : MonoBehaviour
{
    #region HP
    PlayerHealth healthScript;
    Text hpLeft;
    #endregion
    #region Items
    ItemManager itemScript;
    Text gold;
    Text silver;
    #endregion
    void Start()
    {
#region HP
        hpLeft = GetComponent<Text>();
        healthScript = GameObject.FindObjectOfType<PlayerHealth>();

        #endregion
#region Items
        itemScript = GameObject.FindObjectOfType<ItemManager>();
        gold = GameObject.FindGameObjectWithTag("Gold").GetComponent<Text>();
        silver = GameObject.FindGameObjectWithTag("Silver").GetComponent<Text>();
        #endregion
    }
    void Update()
    {
#region HP 
        hpLeft.text = "x" + healthScript.health;

        #endregion
#region Items
        silver.text = "x" + itemScript.carryingSilver;
        gold.text = "x" + itemScript.carryingGold;
        #endregion
    }
}
