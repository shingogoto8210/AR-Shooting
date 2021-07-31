using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    private int highScore;
    private string key = "HIGH SCORE";
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(key, 0);
        highScoreText.text = highScore.ToString();
        scoreText.text = GameMaster.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMaster.score > highScore)
        {
            highScore = GameMaster.score;
            PlayerPrefs.SetInt(key, highScore);
            PlayerPrefs.Save();
            highScoreText.text = highScore.ToString();
        }
    }
}
