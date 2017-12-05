using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject endScreen;

    void Start()
    {
        endScreen.gameObject.SetActive(false);
    }

    public void ShowEndScreen()
    {
        endScreen.gameObject.SetActive(true);
    }

    public void Retry()
    {
        print("CLick");
        SceneManager.LoadScene("Animation Test");
    }

	
}
