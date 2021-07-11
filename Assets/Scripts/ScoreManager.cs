using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private GameMaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        scoreText.text = gameMaster.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameMaster.score.ToString();
    }
}
