using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsBehaviour : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            PlayerHealth pHealth = col.transform.GetComponent<PlayerHealth>();
            pHealth.TakeHit();
            Destroy(gameObject);
        }
    }
}
