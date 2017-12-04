using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBehaviour : MonoBehaviour {
	Animator playerAnim;
	Rigidbody playerRb;
	PlayerHealth damageScript;
	float currentWalkingSpeed;

	void Start () {
		playerAnim = GetComponent<Animator> ();
		damageScript = FindObjectOfType<PlayerHealth> ();
		playerRb = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody>();

	}
	void Update () {
		currentWalkingSpeed = Mathf.Abs(playerRb.velocity.x) + Mathf.Abs( playerRb.velocity.z);
		playerAnim.SetFloat ("CurrentWalkingSpeed", currentWalkingSpeed);


	}
	public void Hurt(){
		playerAnim.SetTrigger ("IsHurt");
	}
}
