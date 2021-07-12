using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTarget : MonoBehaviour
{
    [SerializeField] public GameObject[] TargetPrefabs;
    private int timer;
    private GameMaster gameMaster;


    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer % 60 == 0 && gameMaster.isPlaying == true)
        { 
        float x = Random.Range(-5, 5);
        float z = Random.Range(0, 5);
        int c = Random.Range(0, TargetPrefabs.Length);
        Instantiate(TargetPrefabs[c], new Vector3(x, -0.5f, z), Quaternion.Euler(90f,0,0));
        timer = 0;
        }
    }
}
