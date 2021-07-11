using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private float counttimer;
    public float timer;
    public bool isPlaying;
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
        counttimer++;
        if (counttimer % 60 == 0)
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
}
