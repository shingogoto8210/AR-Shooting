using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private GameMaster gameMaster;
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        scoreText.text = GameMaster.score.ToString();
    }

    void Update()
    {
        scoreText.text = GameMaster.score.ToString();
    }
}
