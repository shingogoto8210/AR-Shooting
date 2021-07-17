using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private float counttimer;
    public float timer;
    public bool isPlaying;
    public int score;
    public GameState currentGameState;

    void Start()
    {
        //isPlaying = true;
        currentGameState = GameState.準備中; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentGameState = GameState.プレイ中;
        }
        if(currentGameState == GameState.プレイ中)
        {
            CountDown();
        }
    }
    void CountDown()
    {
        counttimer += Time.deltaTime;
        if (counttimer >= 1.0)
        {
            timer--;
            counttimer = 0;
        }
        if (timer <= 0)
        {
            Debug.Log("finish");
            //isPlaying = false;
            currentGameState = GameState.ゲーム終了;
        }
    }

    public void Score(int point)
    {
        score += point;
    }
}
