using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private float counttimer;
    public float timer;
    public bool isPlaying;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying == true)
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
            isPlaying = false;
        }
    }

    public void Score(int point)
    {
        score += point;
    }
}
