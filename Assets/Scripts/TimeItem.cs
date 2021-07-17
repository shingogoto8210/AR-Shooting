using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItem : MonoBehaviour
{
    private ShotBullet shotBullet;
    private GameMaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" && gameMaster.isPlaying == true)
        {
            Destroy(gameObject);
            gameMaster.timer += 10;
        }
    }
}
