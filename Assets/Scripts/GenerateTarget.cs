using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTarget : MonoBehaviour
{
    [SerializeField] public GameObject[] TargetPrefabs;
    private GameObject target;
    private float timer;
    private GameMaster gameMaster;

    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1 && gameMaster.currentGameState == GameState.ƒvƒŒƒC’†)
        { 
        float x = Random.Range(-3, 3);
        float z = Random.Range(3, 7);
        int c = Random.Range(0, TargetPrefabs.Length);
        target = Instantiate(TargetPrefabs[c], new Vector3(transform.root.position.x + x, 1.0f, transform.root.position.z + z), Quaternion.Euler(90f,0,0));
        timer = 0;
        Destroy(target, 5.0f);
        }
    }
}
