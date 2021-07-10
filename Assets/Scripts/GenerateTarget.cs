using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTarget : MonoBehaviour
{
    public GameObject TargetPrefab;
    private GameObject target;
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer % 120 == 0)
        { 
        float x = Random.Range(-10, 10);
        float z = Random.Range(0, 5);
        target = Instantiate(TargetPrefab, new Vector3(x, -0.5f, z), Quaternion.Euler(90f,0,0));
        timer = 0;
        }
    }
}
