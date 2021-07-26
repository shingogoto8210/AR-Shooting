using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private float counttimer;
    public float timer;
    public float limitTimer;
    public bool isPlaying;
    public int score;
    public GameState currentGameState;
    public RailMoveController move;

    void Start()
    {
        //isPlaying = true;
        currentGameState = GameState.������;
        timer = limitTimer;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            move.Move();
            currentGameState = GameState.�ړ���;
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
            if(move.isLast == true)
            {
                currentGameState = GameState.�Q�[���I��;
            }
            //isPlaying = false;
            else if (move.isLast == false)
            {
                currentGameState = GameState.�ړ���;
            }
            move.ResumeMove();
            Debug.Log(currentGameState);
            timer = limitTimer;
        }
    }

    public void Score(int point)
    {
        score += point;
    }
}
