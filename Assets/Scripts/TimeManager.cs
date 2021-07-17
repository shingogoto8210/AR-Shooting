using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Text timeText;
    private GameMaster gameMaster;

    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        timeText.text = gameMaster.timer.ToString();
    }

    void Update()
    {
        timeText.text = gameMaster.timer.ToString();
    }
}
