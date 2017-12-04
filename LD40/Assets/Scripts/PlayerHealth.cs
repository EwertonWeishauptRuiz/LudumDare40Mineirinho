using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int initialHealth;
    public int health;
    public float imuneTime;
	//AnimBehaviour animScript;
    ItemManager pItemManager;
    bool imune;
    float timer;

    void Start () {
        pItemManager = GetComponent<ItemManager>();
        imune = false;
        health = initialHealth;
        timer = imuneTime;
		//animScript = GetComponent <AnimBehaviour> ();
	}

    private void Update()
    {
        if (imune)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            imune = false;

            timer = imuneTime;
        }
        
        if (health < 0)
        {
            GameManager.Instance.GameOver(1);
        }
    }

    public void TakeHit()
    {
        if (!imune)
        {
			//animScript.Hurt ();
            health -= 1;
            pItemManager.GetHit();
            imune = true;
        }
    }
}
