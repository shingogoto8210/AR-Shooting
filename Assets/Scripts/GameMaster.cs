using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private float counttimer;
    public float timer;
    public float limitTimer;
    public bool isPlaying;
    public static int score;
    public GameState currentGameState;
    public RailMoveController move;

    void Start()
    {
        isPlaying = false;
        currentGameState = GameState.準備中;
        timer = limitTimer;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlaying == false)
        {
            isPlaying = true;
            move.Move();
            currentGameState = GameState.移動中;
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
            if(move.isLast == true)
            {
                currentGameState = GameState.ゲーム終了;
                isPlaying = false;
                SceneManager.LoadScene("Result");
            }
            //isPlaying = false;
            else if (move.isLast == false)
            {
                move.ResumeMove();
                timer = limitTimer;
                currentGameState = GameState.移動中;
            }
            Debug.Log(currentGameState);
        }
    }

    public void Score(int point)
    {
        score += point;
    }

    public static int GetScore()
    {
        return score;
    }
}
