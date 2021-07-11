using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Text timeText;
    private GameMaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        timeText.text = gameMaster.timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = gameMaster.timer.ToString();
    }
}
