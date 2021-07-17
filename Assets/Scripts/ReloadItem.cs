using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadItem : MonoBehaviour
{
    private ShotBullet shotBullet;
    private GameMaster gameMaster;

    void Start()
    {
        shotBullet = GameObject.Find("ShotBullet").GetComponent<ShotBullet>();
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" && gameMaster.isPlaying == true)
        {
            Destroy(gameObject);
            shotBullet.Reload();
        }
    }
}
