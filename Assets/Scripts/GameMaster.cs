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
        currentGameState = GameState.������; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentGameState = GameState.�v���C��;
        }
        if(currentGameState == GameState.�v���C��)
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
            currentGameState = GameState.�Q�[���I��;
        }
    }

    public void Score(int point)
    {
        score += point;
    }
}
