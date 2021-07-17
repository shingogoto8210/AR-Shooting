using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTarget : MonoBehaviour
{
    [SerializeField] public GameObject[] TargetPrefabs;
    private GameObject target;
    private int timer;
    private GameMaster gameMaster;

    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void Update()
    {
        timer++;
        if (timer % 60 == 0 && gameMaster.currentGameState == GameState.ƒvƒŒƒC’†)
        { 
        float x = Random.Range(-3, 3);
        float z = Random.Range(0, 5);
        int c = Random.Range(0, TargetPrefabs.Length);
        target = Instantiate(TargetPrefabs[c], new Vector3(x, -0.5f, z), Quaternion.Euler(90f,0,0));
        timer = 0;
        Destroy(target, 5.0f);
        }
    }
}
