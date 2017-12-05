using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public void NewGame(){
		SceneManager.LoadScene ("Animation Test", LoadSceneMode.Single);
	}
	public void Exit(){
		Application.Quit ();
	}
}
