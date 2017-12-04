using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBehaviour : MonoBehaviour {
	Animator playerAnim;
	PlayerController walkScript;
	PlayerHealth damageScript;
	float currentWalkingSpeed;

	void Start () {
		playerAnim = GetComponent<Animator> ();
		walkScript = FindObjectOfType<PlayerController> ();
		damageScript = FindObjectOfType<PlayerHealth> ();
	}
	void Update () {
		currentWalkingSpeed = walkScript.walkSpeed;
		playerAnim.SetFloat ("CurrentWalkingSpeed", currentWalkingSpeed);


	}
	public void Hurt(){
		playerAnim.SetTrigger ("IsHurt");
	}
}
