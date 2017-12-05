using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public float timeLimit;
    public bool gameOver;


    float finalScore;
    // 1 == killed, 2 == time is over
    int overType;
    float gameTimer;

    ItemManager pItemManager;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        gameTimer += Time.deltaTime;

        //if(gameTimer > timeLimit)
        //{
        //    GameOver(2);
        //}
    }

    public void GameOver(int deathby)
    {
        gameOver = true;
        overType = deathby;
        finalScore = pItemManager.score;
        UIManager uiMan = GameObject.Find("GameStart").GetComponent<UIManager>();
        uiMan.ShowEndScreen();
        Debug.Log("Game OVER");
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        gameTimer = 0;
        overType = 0;
        gameOver = false;
        pItemManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemManager>();
        Time.timeScale = 1; 
    }

   


}
